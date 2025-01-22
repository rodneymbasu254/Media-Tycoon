using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankManager : MonoBehaviour
{
    public GameObject loanPanel;
    public Text loanDetailsText;
    public Text currentLoanText;
    public Button acceptLoanBtn;
    public Button rejectLoanBtn;

    public GameObject loanItemPrefab;
    public Transform loanListContent;

    public FinanceManager financeManager;

    public class Loan 
    {
        public string bankName;
        public float loanAmount;
        public float interestRate;
        public int repaymentDays;
        public float dailyRepayment;
        public bool active;
        public float remainingAmount;

        public Loan(string bankName, float amount, float interest, int duration)
        {
            this.bankName = bankName;
            loanAmount = amount;
            interestRate = interest;
            repaymentDays = duration;

            float totalRepayment = loanAmount + (loanAmount * (interestRate / 100));
            dailyRepayment = totalRepayment / repaymentDays;
            remainingAmount = totalRepayment;

            active = false;
        }
    }

    private List<Loan> loans = new List<Loan>();
    private Loan currentLoan;

    void Start()
    {
        acceptLoanBtn.onClick.AddListener(AcceptLoan);
        rejectLoanBtn.onClick.AddListener(RejectLoan);

        GenerateLoans();
        PopulateLoanList();
    }

    void GenerateLoans()
    {
        loans.Add(new Loan("Global Bank", 5000f, 5f, 30));
        loans.Add(new Loan("MoneySave Bank", 10000f, 7f, 60));
        loans.Add(new Loan("Capital Trust", 20000f, 10f, 90));
    }

    void PopulateLoanList()
    {
        foreach (Loan loan in loans)
        {
            GameObject item = Instantiate(loanItemPrefab, loanListContent);
            item.GetComponentInChildren<Text>().text = loan.bankName;

            Button button = item.GetComponent<Button>();
            button.onClick.AddListener(() => ShowLoanDetails(loans.IndexOf(loan)));
        }
    }

    public void ShowLoanDetails(int index)
    {
        if (index < 0 || index >= loans.Count)
        {
            return;
        }

        currentLoan = loans[index];
        loanDetailsText.text = $"Bank: {currentLoan.bankName}\n" + $"Amount: ${currentLoan.loanAmount}\n" + $"Interest: {currentLoan.interestRate}%\n" + $"Repayment Days: {currentLoan.repaymentDays}\n" + $"Daily Payment: ${currentLoan.dailyRepayment:F2}\n";
        loanPanel.SetActive(true);
    }

    public void AcceptLoan()
    {
        if (currentLoan != null && !currentLoan.active)
        {
            financeManager.AddIncome(currentLoan.loanAmount);

            currentLoan.active = true;
            loanPanel.SetActive(false);
        }
    }

    public void RejectLoan()
    {
        if (currentLoan != null)
        {
            loanPanel.SetActive(false);
        }
    }

    public void UpdateLoanRepayment()
    {
        foreach (Loan loan in loans)
        {
            if (loan.active)
            {
                loan.remainingAmount -= loan.dailyRepayment;

                financeManager.DeductCash(loan.dailyRepayment);

                if (loan.remainingAmount <= 0)
                {
                    loan.active = false;
                }
            }
        }
    }

    public void ShowLoan()
    {
        if (currentLoan != null)
        {
            currentLoanText.text = "" + currentLoan.ToString();
        }
    }
}
