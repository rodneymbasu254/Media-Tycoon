using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchManager : MonoBehaviour
{
    [System.Serializable]
    public class Merchandise
    {
        public string merchName;
        public float baseIncome;
        public float upgradeCost;
        public int level;
        public float incomeMultiplier = 1.2f;

        public Merchandise(string name, float income, float cost, float multiplier)
        {
            merchName = name;
            baseIncome = income;
            upgradeCost = cost;
            level = 1;
            incomeMultiplier = multiplier;
        }

        public bool Upgrade(FinanceManager financeManager)
        {
            if (financeManager.currentBal >= upgradeCost)
            {
                financeManager.DeductCash(upgradeCost);
                level ++;
                baseIncome *= incomeMultiplier;
                upgradeCost *= 1.5f;
                return true;
            }
            return false;
        }
    }

    public FinanceManager financeManager;
    public Transform merchPanel;
    public GameObject merchItemPrefab;
    private List<Merchandise> merchandiseList;

    void Start()
    {
        merchandiseList = new List<Merchandise>
        {
            new Merchandise("Hoodie", 15f, 100f, 1.2f),
            new Merchandise("T_Shirts", 10f, 50f, 1.3f),
            new Merchandise("Cap", 5f, 40f, 1.15f),
            new Merchandise("Mug", 2f, 30f, 1.1f)
        };

        foreach (Merchandise merch in merchandiseList)
        {
            CreateMerchItemUI(merch);
        }

        //InvokeRepeating("GenerateIncome", 1f, 1f);
    }

    void CreateMerchItemUI(Merchandise merch)
    {
        GameObject item = Instantiate(merchItemPrefab, merchPanel);
        item.transform.Find("NameText").GetComponent<Text>().text = merch.merchName;
        item.transform.Find("IncomeText").GetComponent<Text>().text = "Income: $" + merch.baseIncome.ToString("F2");
        item.transform.Find("UpgradeCostText").GetComponent<Text>().text = "Upgrade: $" + merch.upgradeCost.ToString("F2");
        
        Button upgradeButton = item.transform.Find("UpgradeButton").GetComponent<Button>();
        upgradeButton.onClick.AddListener(() => 
        {
            if (merch.Upgrade(financeManager))
            {
                UpdateMerchItemUI(item, merch);
            }
        });
    }

    void UpdateMerchItemUI(GameObject item, Merchandise merch)
    {
        item.transform.Find("IncomeText").GetComponent<Text>().text = "Income: $" + merch.baseIncome.ToString("F2");
        item.transform.Find("UpgradeCostText").GetComponent<Text>().text = "Upgrade: $" + merch.upgradeCost.ToString("F2");
    }

    public void GenerateIncome()
    {
        float totalIncome = 0f;
        foreach (Merchandise merch in merchandiseList)
        {
            totalIncome += merch.baseIncome;
        }
        financeManager.AddIncome(totalIncome);
    }
}
