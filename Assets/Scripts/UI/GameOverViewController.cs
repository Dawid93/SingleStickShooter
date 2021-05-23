using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverViewController : MonoBehaviour, IInitializable
{
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private TextMeshProUGUI description;
    public void Initialize()
    {
        GameController.GameStateChange += HandleGameStateChanged;
        HideView();
    }

    private void ShowView()
    {
        description.SetText($"You were alive for {gameTimer.GameTime:N2} seconds.");
        gameObject.SetActive(true);
    }

    private void HideView()
    {
        gameObject.SetActive(false);
    }

    private void HandleGameStateChanged(GameStates state)
    {
        switch (state)
        {
            case GameStates.GameStart:
                HideView();
                break;
            case GameStates.GameOver:
                ShowView();
                break;
        }

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
