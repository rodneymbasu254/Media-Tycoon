using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinanceManager : MonoBehaviour
{
    public float currentBal = 1000f;
    public float currentExpenses = 0;
    public float currentIncome = 0;

    public Text balText;
    public Text expensesText;
    public Text incomeText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        balText.text = "$" + currentBal.ToString("N2");
        incomeText.text = "$" + currentIncome.ToString("N2");
        expensesText.text = "$" + currentExpenses.ToString("N2");
    }

    public void AddIncome(float amount)
    {
        currentIncome += amount;
        currentBal += amount;
        UpdateUI();
    }

    public void DeductCash(float amount)
    {
        currentBal -= amount;
        currentExpenses += amount;
        UpdateUI();
    }

    public void DeductSalaries()
    {
        //just pay 'em
        currentBal -= 100f;
    }
}
