using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour {
    public UnityEvent OnTriggerButton3D;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            
            Debug.Log("PLAYER PRESIONANDO EL BOTÓN 3D AMARILLO");
            Debug.Log("EVENTO LLAMADO POR: " + gameObject.name);
            OnTriggerButton3D?.Invoke();
        }
    }
}
