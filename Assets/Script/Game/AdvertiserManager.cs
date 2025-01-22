using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvertiserManager : MonoBehaviour
{
    public GameObject contractPanel;
    public Text contractDetailsText;
    public Button acceptBtn;
    public Button rejectBtn;
    public Button negotiateBtn;

    public GameObject contractItemPrefab;
    public Transform contractListContent;

    public FinanceManager financeManager;

    public class AdvertiserContract
    {
        public string companyName;
        public float paymentAmount;
        public int durationDays;
        public string terms;
        public int negotiationAttempts;
        public bool expired;

        public AdvertiserContract(string name, float payment, int days, string terms)
        {
            companyName = name;
            paymentAmount = payment;
            durationDays = days;
            this.terms = terms;
            negotiationAttempts = 0;
            expired = false;
        }
    }

    private List<AdvertiserContract> advertisers = new List<AdvertiserContract>();
    private AdvertiserContract currentContract;

    void Start()
    {
        acceptBtn.onClick.AddListener(AcceptContract);
        rejectBtn.onClick.AddListener(RejectContract);
        negotiateBtn.onClick.AddListener(NegotiateContract);

        GenerateContracts();
        PopulateContractList();
    }

    void GenerateContracts()
    {
        advertisers.Add(new AdvertiserContract("TechCorp", 500f, 7, "Promote TechCorp products Daily"));
        advertisers.Add(new AdvertiserContract("Foodies Inc", 800f, 10, "Air Food commercials twice per week"));
        advertisers.Add(new AdvertiserContract("AutoDrive", 1200f, 14, "Showcase Autodrive Car in news reports"));
    }

    void PopulateContractList()
    {
        foreach (AdvertiserContract contract in advertisers)
        {
            GameObject item = Instantiate(contractItemPrefab, contractListContent);
            item.GetComponentInChildren<Text>().text = contract.companyName;

            Button button = item.GetComponent<Button>();
            button.onClick.AddListener(() => ShowContract(advertisers.IndexOf(contract)));
        }
    }

    public void ShowContract(int index)
    {
        if (index < 0 || index >= advertisers.Count)
        {
            return;
        }
        currentContract = advertisers[index];
        contractDetailsText.text = $"Company: ${currentContract.companyName}\n" + $"Payment: ${currentContract.paymentAmount}\n" + $"Duration: ${currentContract.durationDays} days\n" + $"Terms: ${currentContract.terms}";
        contractPanel.SetActive(true);
    }

    public void AcceptContract()
    {
        if (currentContract != null && !currentContract.expired)
        {
            financeManager.AddIncome(currentContract.paymentAmount / currentContract.durationDays);

            currentContract.expired = true;
            contractPanel.SetActive(false);
        }
    }

    public void RejectContract()
    {
        if (currentContract != null)
        {
            currentContract.expired = true;
            contractPanel.SetActive(false);
        }
    }

    public void NegotiateContract()
    {
        if (currentContract != null && currentContract.negotiationAttempts < 3)
        {
            currentContract.paymentAmount *= 1.1f;
            currentContract.negotiationAttempts++;

            ShowContract(advertisers.IndexOf(currentContract));
        }
    }

    public void UpdateContracts()
    {
        foreach (var contract in advertisers)
        {
            if (!contract.expired)
            {
                contract.durationDays--;

                if (contract.durationDays <= 0)
                {
                    contract.expired = true;

                    bool willReturn = Random.value > 0.5f;

                    if (willReturn)
                    {
                        contract.paymentAmount *= 1.2f;
                        contract.durationDays = Random.Range(7, 14);
                        contract.expired = false;
                    }
                }
            }
        }
    }
}
