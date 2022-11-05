using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteMover : MonoBehaviour {
    GameObject host;
    bool hit;

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Host")) {
            host = other.gameObject;
            if (Input.GetKey(KeyCode.Space)) {
                print("hit");
                hit = true;
            }
        }
    }    

    void Update() {
        if (hit) {
            //var paraPos = transform.position;
            transform.position = host.transform.position;/*new Vector3(fogOfWarPFPos.x, fogOfWarPFPos.y, caMover.playerPos.z + playerDis);*/
        }
    }
}
