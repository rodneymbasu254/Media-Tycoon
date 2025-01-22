using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameNav : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject bankPanel;
    public GameObject companyPanel;
    public GameObject statsPanel;
    public GameObject summaryPanel;
    public GameObject contractPanel;

    public Button advanceBtn;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        bankPanel.SetActive(false);
        companyPanel.SetActive(false);
        statsPanel.SetActive(false);
        summaryPanel.SetActive(false);
        contractPanel.SetActive(false);

        advanceBtn.interactable = true;
    }

    public void SwitchToBank()
    {
        mainPanel.SetActive(true);
        bankPanel.SetActive(true);
        companyPanel.SetActive(false);
        statsPanel.SetActive(false);
        summaryPanel.SetActive(false);
        contractPanel.SetActive(false);

        advanceBtn.interactable = false;
    }

    public void SwitchToCompany()
    {
        mainPanel.SetActive(true);
        bankPanel.SetActive(false);
        companyPanel.SetActive(true);
        statsPanel.SetActive(false);
        summaryPanel.SetActive(false);
        contractPanel.SetActive(false);

        advanceBtn.interactable = false;
    }

    public void SwitchToStats()
    {
        mainPanel.SetActive(true);
        bankPanel.SetActive(false);
        companyPanel.SetActive(false);
        statsPanel.SetActive(true);
        summaryPanel.SetActive(false);
        contractPanel.SetActive(false);

        advanceBtn.interactable = false;
    }

    public void DisablePanel()
    {
        mainPanel.SetActive(true);
        bankPanel.SetActive(false);
        companyPanel.SetActive(false);
        statsPanel.SetActive(false);
        summaryPanel.SetActive(false);
        contractPanel.SetActive(false);

        advanceBtn.interactable = true;
    }

    public void EnableSummary()
    {
        mainPanel.SetActive(false);
        bankPanel.SetActive(false);
        companyPanel.SetActive(false);
        statsPanel.SetActive(false);
        summaryPanel.SetActive(true);
        contractPanel.SetActive(false);

        advanceBtn.interactable = false;
    }
    
    public void OpenContract()
    {
        GetComponent<AdvertiserManager>().ShowContract(0);
    }
    
    //public void OpenLoan()
    //{
        //GetComponent<BankManager>().ShowLoanDetails(0);
    //}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("DarkUI");
        }
    }
}
