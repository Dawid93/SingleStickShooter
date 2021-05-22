using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		DifficultyController.Instance.SetDifficulty((Difficulties) difficulty);
		LoadNewGame();
	}

	private void EnableDifficultyView(bool enable)
	{
		difficultyView.SetActive(enable);
	}

	private void LoadNewGame()
	{
		SceneManager.LoadScene("Gameplay");
	}
}