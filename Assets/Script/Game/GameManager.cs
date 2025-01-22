using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject summaryPanel;
    public int week = 1;
    public int month = 1;

    public int currentLevel = 0;
    public int currentEmployees = 0;
    public float currentBal = 0;

    public EmployeeManager employeeManager;
    public FinanceManager financeManager;
    public GameNav gameNav;

    private PlayerProgress progress = new PlayerProgress();

    // Start is called before the first frame update
    void Start()
    {
       UpdateUI(); 
       summaryPanel.SetActive(false);
       currentBal = financeManager.currentBal;
       currentEmployees = employeeManager.employeeCount;
    }

    public void UpdateUI()
    {
        //Update UI
    }

    void Update()
    {
        if (financeManager != null)
        {
            currentBal = financeManager.currentBal;
            UpdateUI();
        }
    }

    public void AdvanceWeek()
    {
        week++;
        UpdateUI();
        if (week == 4)
        {
            Debug.Log("End of the month!");
            financeManager.DeductSalaries();
            gameNav.EnableSummary();
            PayTax();
            week = 1;
            month++;
            if (month == 12)
            {
                employeeManager.AddYear();
                Debug.Log("One year reached");
            }
        }
    }

    public void PayTax()
    {
        float taxAmount = 50f;
        financeManager.DeductCash(taxAmount);
    }
}
