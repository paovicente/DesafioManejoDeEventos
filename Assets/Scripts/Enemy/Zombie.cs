using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    [SerializeField] protected ZombieData zombieData;

    [SerializeField] ZombieManager manager;

    private float timer = 0f;

    void Start(){

    }

    // Update is called once per frame
    void Update(){

        timer += Time.deltaTime;
        
        if (manager.ZombieDirectory.ContainsKey(gameObject.name)){    
            Move();
        }
        
    }

    protected virtual void Move(){

        if (timer <= 3f){
            if (timer <= 1.5f)
                transform.Translate(Vector3.forward * zombieData.speed * Time.deltaTime);
            else
                transform.Translate(Vector3.left * zombieData.speed * Time.deltaTime);
        }else
            timer = 0f;
    }

}
