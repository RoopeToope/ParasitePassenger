using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    Free, Hosted, ReadyNewHost, Out
}

public class ParasiteMover : MonoBehaviour {
    public GameState paraState;
    GameObject host;
    GameObject newHost;

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Host")) {
            newHost = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (newHost) {
            newHost = null;
        }
    }

    public float speed;

    void Update() {
        if (newHost && Input.GetKeyDown(KeyCode.Space)) {
            print("host");
            if (host != null) {
                host.GetComponent<SphereCollider>().enabled = true;
            }
            host = newHost;
            paraState = GameState.Hosted;
            host.GetComponent<SphereCollider>().enabled = false;
            newHost = null;
        }
        if (paraState == GameState.Hosted) {
            transform.position = Vector3.MoveTowards(transform.position, host.transform.position, speed * Time.deltaTime);
        }
    }
}
