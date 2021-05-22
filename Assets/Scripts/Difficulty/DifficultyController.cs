using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController Instance { get; private set; }
    public DifficultySettings CurrentDifficultySettings { get; private set; }

    [SerializeField] private DifficultySettings[] settings;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SetDifficulty(Difficulties difficultyLevel)
    {
        CurrentDifficultySettings = GetDifficultySettings(difficultyLevel);
    }

    private DifficultySettings GetDifficultySettings(Difficulties difficultyLevel)
    {
        return settings.First(x => x.DifficultyLevel == difficultyLevel);
    }
}
