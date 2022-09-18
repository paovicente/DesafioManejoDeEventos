using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStalker : Zombie {
   
   [SerializeField] Transform playerTransform;

    public Transform PlayerTransform { get => playerTransform; }

    protected void LookPlayer(){

        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    protected override void Move(){

        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);

        if (direction.magnitude >= 3f)
            transform.position += direction.normalized * zombieData.speed * Time.deltaTime;
    }
}
