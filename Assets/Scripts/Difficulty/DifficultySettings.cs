using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultySettings", menuName = "Difficulty")]
public class DifficultySettings : ScriptableObject
{
    public Difficulties DifficultyLevel => difficultyLevel;
    public float PlayerHealth => playerHealth;
    public float EnemyHealth => enemyHealth;
    public float TimeToSpawn => timeToSpawn;

    [SerializeField] private Difficulties difficultyLevel;
    [SerializeField] private float playerHealth;
    [SerializeField] private float enemyHealth;
    [SerializeField] private float timeToSpawn;
}
