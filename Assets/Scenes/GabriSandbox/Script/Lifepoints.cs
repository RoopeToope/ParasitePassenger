using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifepoints : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public healtBar healtbar;
    void Start()
    {
        currentHealth = maxHealth;
        healtbar.SetMaxHealt(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            TakeDamage(1);
        }
    }void TakeDamage(int damage) {
        currentHealth -= damage;
        healtbar.SetHealt(currentHealth);
    }
}
