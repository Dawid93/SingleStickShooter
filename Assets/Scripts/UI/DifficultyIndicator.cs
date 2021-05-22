using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultyIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private void Awake()
    {
        label.SetText($"Current difficulty {DifficultyController.Instance.CurrentDifficultySettings}");
    }
}
