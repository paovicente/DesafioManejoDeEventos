using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour {
   
    private Light uniqueLight;

    private void Start() {
        uniqueLight = GetComponent<Light>();
    }
    public void ChangeColor(){

        uniqueLight.color = Color.magenta;
    }
}
