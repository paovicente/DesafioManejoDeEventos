using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] GameObject foodManager;

    [SerializeField] ZombieManager zombieManager;

    private PlayerData playerData;
    
    private int countFood = 0;

//----------------- EVENTOS -----------------------
    public static event Action OnDead;
    public static event Action<int> OnChangeHP;

    public static event Action<int> OnChangeScore;

    // Start is called before the first frame update
    void Start(){

        playerData = GetComponent<PlayerData>();
        PlayerCollision.OnChangeHP?.Invoke(playerData.HP);
        PlayerCollision.OnChangeScore?.Invoke(GameManager.Score);
    }

    // Update is called once per frame
    void Update(){
        
        //MANEJAR CASOS DE GAME OVER
        if (GameManager.GameOver == false){

            VerifyCounter();    //desaparecen las comidas

            if (playerData.HP <= 0){
                PlayerCollision.OnDead?.Invoke();
                
                Debug.Log("GAME OVER -- SIN VIDA");
                GameManager.GameOver = true;
            }else if (GameManager.Timer <= 0f){
                PlayerCollision.OnDead?.Invoke();
                
                Debug.Log("GAME OVER -- SIN TIEMPO");
                GameManager.GameOver = true;
            }else if (GameManager.Timer <= 20f && GameManager.Score <= 50){
                PlayerCollision.OnDead?.Invoke();
                
                Debug.Log("GAME OVER -- POCO PUNTAJE");
                GameManager.GameOver = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "cementeryObject"){
            //DAMAGE
            //playerData.Damage(other.gameObject.GetComponent<CemeteryObject>().cementeryData.DamagePoints);
            PlayerEvents.OnDamageCall(other.gameObject.GetComponent<CemeteryObject>().cementeryData.DamagePoints);
            Debug.Log("DAÑO: " + other.gameObject.GetComponent<CemeteryObject>().cementeryData.DamagePoints);
            
            PlayerCollision.OnChangeHP?.Invoke(playerData.HP);
            Debug.Log("VIDA LUEGO DEL DAÑO: " + playerData.HP);

            //HUDManager.SetHPBar(playerData.HP);           
        }

        if (other.gameObject.tag == "enemy"){

            if (zombieManager.ZombieDirectory.ContainsKey(other.gameObject.name) == false){

                zombieManager.ZombieDirectory.Add(other.gameObject.name,other.gameObject);
                Debug.Log("ZOMBIE AGREGADO: " + zombieManager.ZombieDirectory[other.gameObject.name]);
                
                //playerData.Damage(500);
                PlayerEvents.OnDamageCall(other.gameObject.GetComponent<Zombie>().zombieData.DamagePoints);
                PlayerCollision.OnChangeHP?.Invoke(playerData.HP);

                Debug.Log("VIDA LUEGO DEL DAÑO: " + playerData.HP);

                //HUDManager.SetHPBar(playerData.HP);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Food"){
            countFood++;

            FoodManager component = foodManager.GetComponent<FoodManager>();
            component.EatsFood(other.gameObject);

            component.FoodList.Add(other.gameObject);   //agrego la comida a la lista
            
            //HEAL
            
            PlayerEvents.OnHealCall(other.gameObject.GetComponent<FoodData>().HealPoints);
            Debug.Log("VIDA LUEGO DE COMER: " + playerData.HP);
        
            PlayerCollision.OnChangeHP?.Invoke(playerData.HP);

            //HUDManager.SetScoreBar(GameManager.Score);
            GameEvents.OnScoreCall(GameManager.Score);
            PlayerCollision.OnChangeScore?.Invoke(200);     //se le suma 200 puntos de vida cuando come

            Debug.Log("SCORE: " + GameManager.Score);

            if (GameManager.Timer <= 20f && GameManager.Score <= 50){
                component.FoodList.Clear();
                GameManager.GameOver = true;
            }
        }
    }

    private void VerifyCounter(){

        if (countFood == 5){
            FoodManager component = foodManager.GetComponent<FoodManager>();
            component.KillFood();
            countFood = 0;
        }
    }
}
