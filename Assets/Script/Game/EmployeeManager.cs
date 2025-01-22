using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    public int employeeCount = 0;
    public int year = 1;

    public FinanceManager financeManager;

    private EmployeeRecords employeeRecords;
    private int retirementAge = 55;

    public List<EmployeeRecords> employees = new List<EmployeeRecords>();

    public List<EmployeeRecords> joblessPeople = new List<EmployeeRecords>
    {
        new EmployeeRecords { EmployeeName = "Alice", EmployeeRole = "Engineer", EmployeeSalary = 500, morale = 80, EmployeeLevel = 3, age = 30 },
        new EmployeeRecords { EmployeeName = "Bob", EmployeeRole = "Manager", EmployeeSalary = 700, morale = 70, EmployeeLevel = 4, age = 45 },
    };

    // Adds a new employee
    public void AddEmployee(EmployeeRecords person)
    {
        employees.Add(person);
        joblessPeople.Remove(person);
        employeeCount = employees.Count;
    }

    public void FireEmployee()
    {
        //Fire employee if you like
    }

    public void AddYear()
    {
        year += 1;
        employeeRecords.age += 1;
    }
    
    void Retire()
    {
        if (employeeRecords.age == retirementAge)
        {
            employeeRecords.morale = 0;
        }
    }

    public void GetTotalSalary()
    {
        float totalSalary = 0f;
        foreach (var employee in employees)
        {
            totalSalary += employee.EmployeeSalary;
        }
        financeManager.DeductCash(totalSalary);
    }

    public class EmployeeRecords
    {
        public string EmployeeName;
        public string EmployeeRole;
        public float EmployeeSalary;
        public int morale;
        public int EmployeeLevel;
        public int age;

        //void Employee(string employeeName, string employeeRole, float salary, int morale, int level, int age)
        //{
            //employeeName = EmployeeName;
            //employeeRole = EmployeeRole;
            //salary = EmployeeSalary;
            //this.morale = morale;
            //level = EmployeeLevel;
            //this.age = age;
        //}
    }
}

