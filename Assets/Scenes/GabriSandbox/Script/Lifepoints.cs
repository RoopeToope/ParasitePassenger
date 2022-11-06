using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifepoints : MonoBehaviour {
    public int maxHealth = 30;
    public int currentHealth;
    public healtBar healtbar;
    public bool parasiteAttach = false;
    public GameObject DeadBody;

   /* public void OnTriggeStay(Collider other) {

        InYou();

    }
    private void OnTriggerExit(Collider other) {
        parasiteAttach = false;
    }*/
    void Start() {

        // return (timer == 0) ? Destroy(gameObject) : TakeDamage(1);
        currentHealth = maxHealth;
        healtbar.SetMaxHealt(maxHealth);
    }
    float timer = 0f;

    float tickTime = 1;
    // Update is called once per frame
    void Update() {



        if (parasiteAttach == true) {
            
            timer += Time.deltaTime;
            if (timer >= tickTime) {

                timer -= tickTime;
                TakeDamage(1);
            }
        }

       if (currentHealth <= 0) {
            Destroy(gameObject);
            var deadBody = Instantiate(DeadBody);
            deadBody.GetComponent<Rigidbody>().position = transform.position;
            
        }

      /*  if (Input.GetKeyDown(KeyCode.Space)) {

            TakeDamage(1);

        }*/

    


    }
    void TakeDamage(int damage) {
        currentHealth -= damage;
        healtbar.SetHealt(currentHealth);
    }
   /* void InYou() {
      parasiteAttach = true;
    }*/
    
}
