using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameoverPanel;

    public void SetScoreText(string txt)
    {
        if (scoreText)
            scoreText.text = txt;
    }

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
            gameoverPanel.SetActive(isShow);
    }
}
