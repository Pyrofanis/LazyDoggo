using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BillsSchedule),typeof(Callendar))]
public class BillManager : MonoBehaviour
{
    public delegate void ChangeBill(BillsSO billsSO);
    public static event ChangeBill OnChangeBill;

    [Header("Bills active")]
    [SerializeField]
    private BillsSO[] bills;
    private void Start()
    {
        ResetBills();
    }
    public void Update()
    {
        CheckBills();
    }
    public static void ChangeCurrentBill(BillsSO billSo)
    {
        if (OnChangeBill != null)
        {
            OnChangeBill(billSo);
        }
    }

    private void CheckBills()
    {
        foreach (BillsSO bill in bills)
        {
            ChangeCurrentBill(bill);
        }
    }
    private void ResetBills()
    {
        foreach (BillsSO bill in bills)
        {
            bill.currentState = BillsSO.billState.payed;
            bill.interestRate = 1;
            bill.previousInterestRate = 1;
            bill.timeLeftUnpaid = 0;
        }
    }
}
