using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyIndicator : MonoBehaviour, IInitializable
{
    [SerializeField] private TextMeshProUGUI label;

    public void Initialize()
    {
        label.SetText($"Current difficulty {DifficultyController.Instance.CurrentDifficultySettings}");
    }
}
