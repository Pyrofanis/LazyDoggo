using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralIndicator : MonoBehaviour
{
    [Header("Txt to indicate budgetTXT")]
    public TextMeshProUGUI budgetTXT;
    [Header("Txt to indicate bills")]
    public TextMeshProUGUI billsTXT;
    [Header("Txt to indicate yearly days leave")]
    public TextMeshProUGUI callendarTXT;

    [SerializeField]
    [Header("Adjoint text with budget")]
    private string budgetString;
    [SerializeField]
    [Header("Adjoint text with Bills")]
    private string billsString;


    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        budgetTXT.text = budgetString + PaymentScedule.budget.ToString("0.0");
        billsTXT.text = billsString+BillsSchedule.billsSum.ToString("0.0");
        callendarTXT.text = Callendar.actualDaysInAmounth+ " " + CurrentMounth(Callendar.MounthsCounter()) + " "+ Callendar.YearsCounter();
    }
    private string CurrentMounth(int currentMounth)
    {
        switch (currentMounth)
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September"; 
            case 10:
                return "Octomber";
            case 11:
                return "November";
            case 12:
                return "December";
        }
        return "January";

    }
}
