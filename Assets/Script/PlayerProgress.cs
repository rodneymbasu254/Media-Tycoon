using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress
{
    public int currentWeek = 1;
    public float cash = 5000f;
    public float loan = 0f;
    public float income = 0f;
    public float expenses = 0f;
    public int reputation = 0;
    public int employees = 0;
    public int contracts = 0;

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("CurrentWeek", currentWeek);
        PlayerPrefs.SetFloat("Cash", cash);
        PlayerPrefs.SetFloat("Loan", loan);
        PlayerPrefs.SetFloat("Income", income);
        PlayerPrefs.SetFloat("Expenses", expenses);
        PlayerPrefs.SetInt("Reputation", reputation);
        PlayerPrefs.SetInt("Employees", employees);
        PlayerPrefs.SetInt("Contracts", contracts);

        PlayerPrefs.Save();
        Debug.Log("game saved");
    }

    public void LoadProgress()
    {
        currentWeek = PlayerPrefs.GetInt("CurrentWeek", 1);
        cash = PlayerPrefs.GetFloat("Cash", 5000f);
        loan = PlayerPrefs.GetFloat("Loan", 0f);
        income = PlayerPrefs.GetFloat("Income", 0f);
        expenses = PlayerPrefs.GetFloat("Expenses", 0f);
        reputation = PlayerPrefs.GetInt("Reputation", 0);
        employees = PlayerPrefs.GetInt("Employees", 0);
        contracts = PlayerPrefs.GetInt("Contracts", 0);

        Debug.Log("Game Loaded");
    }

    public bool SaveExists()
    {
        return PlayerPrefs.HasKey("CurrentWeek");
    }
}
