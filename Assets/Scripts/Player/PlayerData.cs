using UnityEngine;

public class PlayerData : MonoBehaviour {

    private int live = 2000;
    public int HP { get { return live; } }

    private void OnEnable(){
        PlayerEvents.OnHeal += Healing;
        PlayerEvents.OnDamage += Damage;
    }

    private void OnDisable(){
        PlayerEvents.OnHeal -= Healing;
        PlayerEvents.OnDamage -= Damage;
    }

    public void Healing(int value){
        live += value;
    }

    public void Damage(int value){
        live -= value;
    }

}
