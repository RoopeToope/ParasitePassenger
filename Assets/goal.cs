using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class goal : MonoBehaviour {
    public UnityEvent triggerOn;
    [SerializeField] TextMeshProUGUI winGameText;
    int characterInside = 0;
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ParasiteMover>() != null) {
            if (characterInside == 0) {
                print("Stage Cleared");
                triggerOn.Invoke();
            }
            characterInside++;
            Win();
        }

    }
    public void Win() {
        //win Game 
        winGameText.enabled = true;
        Time.timeScale = 0f;// pause the game
    }
}
