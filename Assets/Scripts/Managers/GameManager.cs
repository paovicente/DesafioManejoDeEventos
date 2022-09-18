using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static int score = 100;
    public static int Score { get => score; set => score = value; }

    private static float time = 100f;

    public static float Timer {get => time; set => time = value; }

    public static GameManager instance;

    public static bool GameOver = false;

    private void Update() {
        if (time > 0 && GameOver == false) {
            time -= Time.deltaTime;
            Debug.Log("time: " + time);
        }
    }

    private void Awake(){

        if (instance == null){   
            instance = this;
            score = 0;

            PlayerCollision.OnChangeScore += SetScore;

            DontDestroyOnLoad(gameObject);
        }else
            Destroy(gameObject);     
    }

    private void OnDisable(){

        PlayerCollision.OnChangeScore -= SetScore;
    }

    public static void SetScore(int newValue){

        score += newValue;
        Debug.Log("nuevo valor: " + newValue + "DESDE EL Game Manager "+ score);
    }
}

