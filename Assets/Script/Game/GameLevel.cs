using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel : MonoBehaviour
{
    public int gameLevel = 1;

    public Text levelText;
    public GameManager gameManager;
    public FinanceManager financeManager;
    
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        levelText.text = "" + gameLevel.ToString();
    }

    void IncreaseLevel()
    {
        gameLevel += 1;
        UpdateUI();
    }

    void CheckLevel()
    {
        if (financeManager.currentBal >= 5000f)
        {
            IncreaseLevel();
        }
    }
}
