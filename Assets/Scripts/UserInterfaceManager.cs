using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance;

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI ammoDisplay;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverPanel;

    public void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        GameOverDisplay();
    }

    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.ScoreDisplay();
    }

    public void GameOverDisplay()
    {
        if(gameOverPanel.activeSelf == true)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            finalScoreText.text = "Final Score: " + GameManager.Instance.ScoreDisplay();
            gameOverPanel.SetActive(true);
        }
    }
}
