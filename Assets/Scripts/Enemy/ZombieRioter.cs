using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRioter : ZombieStalker {
    
    public void RotateAroundPlayer(){

        LookPlayer();
        transform.RotateAround(PlayerTransform.position, Vector3.up, 10f * Time.deltaTime);
    }
}
