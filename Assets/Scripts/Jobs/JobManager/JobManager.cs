using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Callendar),typeof(PaymentScedule),typeof(CrunchImplementation))]
public class JobManager : MonoBehaviour
{
    public  delegate void ChangeJob(JobsSO jobType);
    public static event ChangeJob OnJobChange;

    public static JobsSO currentJob;

    [Header("DefaultJob")]
    [SerializeField]
    private JobsSO defaultJob;

    [Header("Jobs Available")]
    [SerializeField]
    private JobsSO[] Jobs;

    private void Start()
    {
        ChangeCurrentJob(defaultJob);
        ResetJobs();
    }
    private void Update()
    {
        if (currentJob!=null)
        ChangeCurrentJob(currentJob);
        CrunchReseter();
    }
    public static void ChangeCurrentJob(JobsSO jobType)
    {
        if (OnJobChange != null)
        {
            OnJobChange(jobType);
        }
    }

    private void ResetJobs()
    {
        foreach (JobsSO jobsSO in Jobs)
        {
            jobsSO.crunchCapabilitiesModifiable = 0;
            jobsSO.paymentRate = 0;
            jobsSO.timeInJob = 0;
            jobsSO.protested = false;
            jobsSO.unionized = false;
        }
    }
    private void CrunchReseter()
    {
        foreach (JobsSO jobsSO in Jobs)
        {
            ResetCrunch(jobsSO);
        }
    }
    private void ResetCrunch(JobsSO jobsSO)
    {
        if (Callendar.actualDaysInAmounth == 1 && Callendar.MounthsCounter() % 2 == 0)
        {
            if (jobsSO.crunchCapabilitiesModifiable <= 0)
                jobsSO.crunchCapabilitiesModifiable = jobsSO.crunchDays;
        }
    }
}
