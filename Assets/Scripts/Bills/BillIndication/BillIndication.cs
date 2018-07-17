using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BillIndication : MonoBehaviour
{
    [SerializeField]
    [Header("Txt to indicate currentBill")]
    private TextMeshProUGUI billsTXT;
    [SerializeField]
    [Header("Txt to indicate cost")]
    private TextMeshProUGUI costTXT;
    [SerializeField]
    [Header("Txt to indicate Daily Payment Inc")]
    private TextMeshProUGUI interestRateTXT;
    [SerializeField]
    [Header("Txt to indicate yearly days leave")]
    private TextMeshProUGUI UnpayedNStatesTXT;
    [SerializeField]
    [Header("Txt to indicate what bill to pay")]
    private TextMeshProUGUI confirmationPanelTXT;

    [SerializeField]
    [Header("Adjoint text with Payment Check")]
    private string monthlyPaymentString;
    [SerializeField]
    [Header("Adjoint text with interest rate")]
    private string interestRateString;
    [SerializeField]
    [Header("Adjoint text with daysNotPayed")]
    private string unpayedDayesString;    
    [SerializeField]
    [Header("Adjoint text with confirmation panel ")]
    private string confirmationPanelString;

    [Header("Add the default Values SO")]
    [SerializeField]
    protected   BillsSO defaultBill;

    //[HideInInspector]
    public Button currentButton;

    [HideInInspector]
    public bool currentlyAbuttonIsSelected;
    [System.Serializable]
    public struct ButtonNJob
    {
        public Button button;
        public BillsSO currentBill;
        public ButtonNJob(Button newButton, BillsSO newBill)
        {
            this.button = newButton;
            this.currentBill = newBill;
        }
    }
    public List<ButtonNJob> currentButtonsNJob;

    private void Update()
    {
        TextDisplayers();
        PayedBill();
    }
    //display texts
    private void TextDisplayers()
    {
        DisplayTXT(SelectedBill().bill.ToString(), billsTXT);
        DisplayTXT(monthlyPaymentString + (SelectedBill().cost * SelectedBill().interestRate).ToString("0,0"), costTXT);
        DisplayTXT(interestRateString + SelectedBill().interestRate, interestRateTXT);
        DisplayTXT(confirmationPanelString + SelectedBill().bill.ToString() + " bill", confirmationPanelTXT);
        displayCurrentBillState();
    }
    private void displayCurrentBillState()
    {
        if (SelectedBill().timeLeftUnpaid > 0)
        {
            DisplayTXT(unpayedDayesString +Mathf.RoundToInt(SelectedBill().timeLeftUnpaid), UnpayedNStatesTXT);
        }
        else
        {
            DisplayTXT(SelectedBill().currentState.ToString(), UnpayedNStatesTXT);
        }
    }
    private void DisplayTXT(string currentString,TextMeshProUGUI text)
    {
        text.text = currentString;
    }
    //display texts

    //determine selected bill
    public BillsSO SelectedBill()
    {
        if (currentButton != null)
        {
            foreach (ButtonNJob button in currentButtonsNJob)
            { 
                if (button.button.Equals(currentButton))
                {
                    return button.currentBill;
                }
            }
        }
      return defaultBill;
    }
    //determine selected bill

    //deselect current bill
    public void DeselectButton()
    {
        currentlyAbuttonIsSelected = false;
    }
    //deselect current bill

    //make payed bills  interactable or not and change colour
    private void PayedBill()
    {
        foreach (ButtonNJob button in currentButtonsNJob)
        {
            if (button.currentBill.currentState.Equals(BillsSO.billState.payed))
            {
                button.button.interactable = false;
            }
            else if (button.currentBill.cost <= PaymentScedule.budget)
            {
                button.button.interactable = true;
            }
            else
            {
                button.button.interactable = true;
            }
        }
    }
    //make payed bills not interactable
}
