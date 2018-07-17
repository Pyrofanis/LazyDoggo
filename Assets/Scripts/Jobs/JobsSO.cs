using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="JobData",menuName = "LazzyDoggo/DataContainers/jobData", order =0)]
public class JobsSO : ScriptableObject
{
    public enum jobType
    {
        Janitor,
        programmer,
        waiter,
        captain,
        refuseCollector,
        electrician,
        taxiDriver,
        delivery,
        teacher,
        unemployed
    }
    public enum State
    {
        gotPayed,
        unpayed
    }
    public jobType job;

    [Header("Paycheck")]
    [Range(0, 2000)]
    public float monthlyPayment;
    [Header("Rate at which salary Is Increased")]
    [Range(0, 2)]
    public float paymentRate;

    [Header("maxPaymentRate")]
    [Range(1, 2)]
    public float maxPayRate;

    [Header("maximum time in mounths to reach expertise")]
    [Range(365, 1460)]
    public int timeToExpertise;

    [Header("Days that you can crunch")]
    [Range(0, 30)]
    public int crunchDays;

    [HideInInspector]
    [Range(0, 30)]
    public int crunchCapabilitiesModifiable;

    [Header("Job Experience")]
    [Range(0, 99999)]
    public float timeInJob;

    [Header("paycheckState")]
    public State paycheckState;

    [HideInInspector]
    public bool unionized;
    [HideInInspector]
    public bool protested;
}
