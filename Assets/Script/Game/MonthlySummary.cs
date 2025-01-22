using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthlySummary : MonoBehaviour
{
    public float currentBal;
    public float currentExpenses;
    public int employeeCount;
    public float profit = 1000f;
    public float negProfit;
    public float taxPayable = 50f;

    public Text balText;
    public Text profitText;
    public Text negProfitText;
    public Text expensesText;
    public Text employeeText;
    public Text taxText;

    public FinanceManager financeManager;
    public EmployeeManager employeeManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
        CheckProfit();
        currentBal = financeManager.currentBal;
        currentExpenses = financeManager.currentExpenses;
        employeeCount = employeeManager.employeeCount;
    }

    void CheckProfit()
    {
        profit = currentBal - currentExpenses;
        if (profit <= 0)
        {
            negProfit = profit;
            profitText.gameObject.SetActive(false);
            negProfitText.gameObject.SetActive(true);
            negProfitText.text = "$" + negProfit.ToString("N2");
        }
        else
        {
            negProfitText.gameObject.SetActive(false);
            profitText.gameObject.SetActive(true);
            profitText.text = "$" + profit.ToString("N2");
        }
    }

    void Update()
    {
        if (financeManager != null)
        {
            currentBal = financeManager.currentBal;
            UpdateUI();
        }
    }
    
    public void UpdateUI()
    {
        balText.text = "$" + currentBal.ToString("N2");
        expensesText.text = "$" + currentExpenses.ToString("N2");
        employeeText.text = "" + employeeCount.ToString();
        taxText.text = "$" + taxPayable.ToString("N2");
    }
}
