using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonZombie : MonoBehaviour {
    public UnityEvent OnTriggerButtonZombie;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            
            Debug.Log("PLAYER PRESIONANDO EL BOTÓN");
            OnTriggerButtonZombie?.Invoke();
        }
    }
}
