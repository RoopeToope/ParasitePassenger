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

    [SerializeField] private float playerLifetime = 6;
    private float timer = 6;

    void Awake() {
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Host")) {
            newHost = other.gameObject;
            triggerSize = newHost.GetComponent<SphereCollider>().radius;
            if (rotator != null) {
                var pointerColor = pointer.GetComponent<Renderer>();
                pointerColor.material.color = Color.green;
            }
        } else if (rotator != null) {
            var pointerColor = pointer.GetComponent<Renderer>();
            pointerColor.material.color = Color.black;
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
        if (host != null) {
            host.GetComponent<Lifepoints>().parasiteAttach = paraState == GameState.Hosted;
            host.GetComponent<SphereCollider>().enabled = paraState != GameState.Hosted;
            }


            if (paraState == GameState.Hosted) {
            if (host != null) {
                transform.position = Vector3.MoveTowards(transform.position, host.transform.position + Vector3.up * 0.5f, speed * Time.deltaTime);
            } else {
                paraState = GameState.Missed;
            }
        }
        if (paraState == GameState.Missed) {
            transform.position = Vector3.MoveTowards(transform.position, finalJump, speed * Time.deltaTime);
            //Invoke("maybeDestroy", 3);
            timer -= Time.deltaTime;
            if (timer <= 0) {
                Destroy(rotator);
            }
        } else
            timer = playerLifetime;
    }

    //void maybeDestroy() {
    //    if (paraState == GameState.Missed) {
    //        Destroy(rotator);
    //    }
    //}

    public float rotateMultiplier;
    public GameObject pointer;

    void FixedUpdate() {
        float dirX = Input.GetAxis("Horizontal") * speedAim * Time.fixedDeltaTime;
        if (rotator != null) {
            rotator.transform.Rotate(Vector3.up, dirX * rotateMultiplier);
            aimDir = (pointer.transform.position - transform.position).normalized;
        }
        //var aimAngle = rotator.transform.eulerAngles.y; 
        RaycastHit hit;
        ray1 = Physics.Raycast(transform.position, aimDir, out hit, triggerSize);
        //print(triggerSize);
        if (ray1) {
            print("Shoot now!");
        }
    }
}
