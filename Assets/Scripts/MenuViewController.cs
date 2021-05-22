using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuViewController : MonoBehaviour
{
	[SerializeField] private GameObject difficultyView;

	private void Awake()
	{
		EnableDifficultyView(false);
	}

	public void NewGame()
	{
		EnableDifficultyView(true);
	}

	public void Exit()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}

	public void BackToMenu()
	{
		EnableDifficultyView(false);
	}

	public void SetDifficulty(int difficulty)
	{
		Debug.Log($"Selected difficulty {(Difficulties)difficulty}");
		LoadNewGame();
	}

	private void EnableDifficultyView(bool enable)
	{
		difficultyView.SetActive(enable);
	}

	private void LoadNewGame()
	{
		
	}
}