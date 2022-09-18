using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cemetery Data", menuName = "Create Cemetery Data")]
public class CemeteryData : ScriptableObject {

    [SerializeField][Range(20, 1000)] private int damagePoints = 20;
    public int DamagePoints { get { return damagePoints; } }

}