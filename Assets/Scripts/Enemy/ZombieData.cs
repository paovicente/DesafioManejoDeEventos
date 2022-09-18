using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie Data", menuName = "Create Zombie Data")]
public class ZombieData : ScriptableObject {
     
    [Header("Movement Configuration")]

    [Tooltip("The movement velocity is between 0.25 and 10")]
    [SerializeField] [Range(0.25f, 10f)] public float speed = 2f;

//----------------------------------------------------------------------
    [Header("Damage Points")]

    [Tooltip("The damage points are between 50 and 600")]
    [SerializeField][Range(50, 600)] private int damagePoints = 500;
    public int DamagePoints { get { return damagePoints; } }
}