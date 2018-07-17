using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BillRepayment : MonoBehaviour
{
    private Button button;
    private BillIndication billIndication;
    private void Awake()
    {
        button = GetComponent<Button>();
        billIndication = GetComponentInParent<BillIndication>();

    }
    private void Start()
    {
        button.onClick.AddListener(PayBills);
    }

    private void Update()
    {
        whentToEnableButton();
    }
    private void whentToEnableButton()
    {
        if (PaymentScedule.budget >= billIndication.SelectedBill().cost)
            button.interactable = true;
        else
            button.interactable = false;
    }
    public void PayBills()
    {
        BillsSchedule.RepayBill(billIndication.SelectedBill());
    }
}
