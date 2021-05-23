using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("DifficultyController", typeof(DifficultyController)).GetComponent<DifficultyController>();
            }

            return instance;
        }
    }

    private static DifficultyController instance = null;
    public DifficultySettings CurrentDifficultySettings { get; private set; }

    [SerializeField] private DifficultySettings[] settings;
    
    private Difficulties defaultDifficulty = Difficulties.Normal;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (settings == null || settings.Length == 0)
                settings = LoadSettings();
            SetDifficulty(defaultDifficulty);
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

    private DifficultySettings[] LoadSettings()
    {
        return Resources.LoadAll<DifficultySettings>("Difficulties");
    }
}
