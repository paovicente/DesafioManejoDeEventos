using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    // Start is called before the first frame update
    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }

    [SerializeField] private Slider hpBar;

    [SerializeField] private Slider scoreBar;
    private PlayerData playerData;

    private void Start() {
        playerData= GetComponent<PlayerData>();
        HUDManager.SetHPBar(playerData.HP);
    }

    private void Awake(){
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null){
            instance = this;
            Debug.Log(instance);
        }
        else      
            Destroy(gameObject);      
    }

    public static void SetHPBar(int newValue){

        instance.hpBar.value = newValue;
    }

    public static void SetScoreBar(int newValue){

        instance.scoreBar.value = newValue;
    }

}