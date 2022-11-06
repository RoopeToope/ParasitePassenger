using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    Free, Hosted, ReadyNewHost, Missed
}

public class ParasiteMover : MonoBehaviour {
    public GameState paraState;
    public GameObject rotator;
    GameObject host;
    GameObject newHost;
    float triggerSize;

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Host")) {
            newHost = other.gameObject;
            triggerSize = newHost.GetComponent<SphereCollider>().radius;
            var pointerColor = pointer.GetComponent<Renderer>();
            pointerColor.material.SetColor("PointerColor", Color.green);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (newHost) {
            newHost = null;
        }
    }

    public float speed;
    public float speedAim;
    bool ray1;
    Vector3 aimDir;
    public GameObject deathPoint;
    Vector3 finalJump;

    void Update() {
        if (newHost == null && Input.GetKeyDown(KeyCode.Space)) {
            finalJump = deathPoint.transform.position;
            paraState = GameState.Missed;
        }
        if (newHost && Input.GetKeyDown(KeyCode.Space)) {
            if (host != null) {
                host.GetComponent<SphereCollider>().enabled = true;
            }
            if (ray1) { 
            host = newHost;
            paraState = GameState.Hosted;
            host.GetComponent<SphereCollider>().enabled = false;
            newHost = null;
            }
        }
        if (paraState == GameState.Hosted) {
            transform.position = Vector3.MoveTowards(transform.position, host.transform.position + Vector3.up * 0.6f, speed * Time.deltaTime);
        }
        if (paraState == GameState.Missed) {
            transform.position = Vector3.MoveTowards(transform.position, finalJump + Vector3.up * 0.6f, speed * Time.deltaTime);
        }
    }

    void Awake() {
    }

    public float rotateMultiplier;
    public GameObject pointer;

    void FixedUpdate() {
        float dirX = Input.GetAxis("Horizontal") * speedAim * Time.fixedDeltaTime;
        rotator.transform.Rotate(Vector3.up, dirX * rotateMultiplier);
        //var aimAngle = rotator.transform.eulerAngles.y;
        aimDir = (pointer.transform.position - transform.position).normalized;
        RaycastHit hit;
        ray1 = Physics.Raycast(transform.position, aimDir, out hit, triggerSize);
        //print(triggerSize);
        if (ray1) { 
            print("Shoot now!");
        }
    }
}
