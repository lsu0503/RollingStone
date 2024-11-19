using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        StageManager.Instance.OnGameOverEvent += DisplayGameOverUI;
        gameObject.SetActive(false);
    }

    private void DisplayGameOverUI()
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }

    public void OnRetryButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}