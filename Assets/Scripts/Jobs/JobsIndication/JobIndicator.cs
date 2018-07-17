using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobIndicator : MonoBehaviour
{
    //stats texts
    [SerializeField]
    [Header("Txt to indicate Monthly Payment")]
    private TextMeshProUGUI paymentTXT;
    [Header("Txt to indicate Daily Payment Inc")]
    [SerializeField]
    private TextMeshProUGUI paymentRateTXT;
    [Header("Txt to indicate cranch")]
    [SerializeField]
    private TextMeshProUGUI cranchTXT;
    [Header("Txt to indicate selectedJob")]
    [SerializeField]
    private TextMeshProUGUI selectedJobTXT;
    [Header("Txt to indicate selectedJobInConfirmationPanel")]
    [SerializeField]
    private TextMeshProUGUI confirmationTXT;
    [Header("Txt to indicate currentEXp")]
    [SerializeField]
    private TextMeshProUGUI expTXT;
    //stats texts

    //stats strings
    [SerializeField]
    [Header("Adjoint text with Payment Check")]
    private string monthlyPaymentString;
    [SerializeField]
    [Header("Adjoint text with Payment rate")]
    private string paymentRateIncreaseString;
    [SerializeField]
    [Header("Adjoint text with cranch")]
    private string cranchString;
    [SerializeField]
    [Header("Adjoint text with confirmationPanel")]
    private string confirmationPanelString;
    [SerializeField]
    [Header("Adjoint text with expTXT")]
    private string expString;
    //stats strings


    [Header("Add the default Values SO")]
    [SerializeField]
    protected   JobsSO defaultUnemployed;

    [HideInInspector]
    public Button currentButton;

    [HideInInspector]
    public bool buttonCurrentlySelected;
    [System.Serializable]
    public struct ButtonNJob
    {
        public Button button;
        public JobsSO currentJob;
        public ButtonNJob(Button newButton,JobsSO newCurrentJob)
        {
            this.button = newButton;
            this.currentJob = newCurrentJob;
        }
    }
    public List<ButtonNJob> currentButtonsNJob;

    private void Update()
    {
        DisplayTXT( monthlyPaymentString + SelectedJob().monthlyPayment, paymentTXT);
        DisplayTXT(paymentRateIncreaseString + SelectedJob().maxPayRate, paymentRateTXT);
        DisplayTXT(cranchString + SelectedJob().crunchDays+" days", cranchTXT);
        DisplayTXT(SelectedJob().job.ToString(), selectedJobTXT);
        DisplayTXT(expString +Mathf.RoundToInt(SelectedJob().timeInJob)+"/"+Mathf.RoundToInt(SelectedJob().timeToExpertise), expTXT);
        DisplayTXT(confirmationPanelString + SelectedJob().job.ToString(), confirmationTXT);

    }
    private void DisplayTXT(string currentString,TextMeshProUGUI text)
    {
        text.text = currentString;
    }
    public JobsSO SelectedJob()
    {
        if (currentButton != null)
        {
            foreach (ButtonNJob button in currentButtonsNJob)
            { 
                if (button.button.Equals(currentButton))
                {
                    return button.currentJob;
                }
            }
        }
      return defaultUnemployed;

    }
    public void DeselectButton()
    {
        buttonCurrentlySelected = false;
    }
}
