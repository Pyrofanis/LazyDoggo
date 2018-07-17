using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillsSchedule : MonoBehaviour
{
    public static float billsSum;
    // Start is called before the first frame update
    void Start()
    {
        BillManager.OnChangeBill += addBill;
        BillManager.OnChangeBill += BillRateAdjuster;
        BillManager.OnChangeBill += UpdateBill;
    }
    //update bill
    private void UpdateBill(BillsSO billsSO)
    {
        if (billsSO.interestRate != billsSO.previousInterestRate)
        {
            billsSum -= billsSO.cost * billsSO.previousInterestRate;
            billsSum += billsSO.cost * billsSO.interestRate;
            billsSO.previousInterestRate = billsSO.interestRate;
        }

    }
    ///bill to add
    private void addBill(BillsSO billsSO)
    {
        if (Callendar.actualDaysInAmounth==1&&Callendar.MounthsCounter()!=1)
        {
            if (billsSO.currentState.Equals(BillsSO.billState.payed))
            AddSumToBeRepayed(billsSO);
        }
    }

    private void AddSumToBeRepayed(BillsSO billsSO)
    {
        billsSum +=billsSO.cost * billsSO.interestRate;
        billsSO.previousInterestRate = billsSO.interestRate;
        billsSO.currentState = BillsSO.billState.unpayed;
    }
    private void BillRateAdjuster(BillsSO billsSO)
    {
        if (billsSO.currentState.Equals(BillsSO.billState.unpayed))
        {
            billsSO.timeLeftUnpaid += Time.deltaTime;
            billsSO.interestRate = Mathf.Clamp(0.5f* Mathf.RoundToInt(billsSO.timeLeftUnpaid / Callendar.staticTimerPerDay)/24, 1, 4);
        }
    }
    //

    //Repayment
    public static void RepayBill(BillsSO billsSO)
    {
        billsSO.timeLeftUnpaid = 0;
        billsSum -=billsSO.cost * billsSO.interestRate;
        PaymentScedule.budget-=billsSO.cost * billsSO.interestRate;
        billsSO.currentState = BillsSO.billState.payed;
        billsSO.interestRate = 1;
        billsSO.previousInterestRate = billsSO.interestRate;
    }
    //

}
