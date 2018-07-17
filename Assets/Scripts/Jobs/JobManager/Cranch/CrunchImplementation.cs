using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrunchImplementation : MonoBehaviour
{
    [SerializeField]
    [Header("Cranch button")]
    private Button button;
    private bool initiated;
    private TextMeshProUGUI buttonTxt;
    private float timer;

    private void Awake()
    {
        buttonTxt =button.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
    }

    // Update is called once per frame
    void Update()
    {
        StartCounter();
    }
    private void SubscribeToEvents()
    {
        button.onClick.AddListener(InitateOnClick);
        button.onClick.AddListener(GetMoney);
        JobManager.OnJobChange += InitiateLeaveDays;
        JobManager.OnJobChange += DisplayText;
        JobManager.OnJobChange += EnableButton;
    }
    public void InitateOnClick()
    {
        initiated = true;
    }
    //text displayer
    private void DisplayText(JobsSO jobsSO)
    {
        if (initiated)
            buttonTxt.text =jobsSO.crunchCapabilitiesModifiable.ToString();
        else buttonTxt.text = "Crunch";
    }
    //text displayer

    //money Collection
    private void GetMoney()
    {
      if( JobManager.currentJob.crunchCapabilitiesModifiable>0)
        PaymentScedule.budget +=JobManager.currentJob.monthlyPayment*JobManager.currentJob.paymentRate*0.01f;
    }
    //money Collection

    //initiate money collection
    private void InitiateLeaveDays(JobsSO jobsSO)
    {
        if (initiated)
            timer += Time.deltaTime;
        if (timer>=Callendar.staticTimerPerDay&&jobsSO.crunchCapabilitiesModifiable>0)
        {
            jobsSO.crunchCapabilitiesModifiable -- ;
            timer = 0;
        }
        if (jobsSO.crunchCapabilitiesModifiable<=0)
        {
            initiated = false;
        }
    }
    private void StartCounter()
    {
        if (initiated)
        {
            timer += Time.deltaTime;
        }
    }
    //initiate money collection

    //button enabler
    private void EnableButton(JobsSO jobsSO)
    {
        if (jobsSO.crunchCapabilitiesModifiable > 0&&jobsSO.job!=JobsSO.jobType.unemployed)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }
    //button enabler
}
