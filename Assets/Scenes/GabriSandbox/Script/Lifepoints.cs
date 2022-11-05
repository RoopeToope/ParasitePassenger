using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifepoints : MonoBehaviour {
    public int maxHealth = 5;
    public int currentHealth;
    public healtBar healtbar;
    void Start() {

        // return (timer == 0) ? Destroy(gameObject) : TakeDamage(1);
        currentHealth = maxHealth;
        healtbar.SetMaxHealt(maxHealth);
    }
    float timer = 60;
    // Update is called once per frame
    void Update() {
        /*  timer - = Time.time;


          return (timer == 0) ? Destroy(gameObject) : TakeDamage(1);*/

        if (Input.GetKeyDown(KeyCode.Space)) {

            TakeDamage(1);

        }
        void TakeDamage(int damage) {
            currentHealth -= damage;
            healtbar.SetHealt(currentHealth);
        }



    }
}
