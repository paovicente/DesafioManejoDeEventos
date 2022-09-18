using UnityEngine;

public class PlayerData : MonoBehaviour {

    private int live = 2000;
    public int HP { get { return live; } }

    public void Healing(int value){
        live += value;
    }

    public void Damage(int value){
        live -= value;
    }

}
