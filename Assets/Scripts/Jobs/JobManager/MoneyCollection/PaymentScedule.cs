using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaymentScedule : MonoBehaviour
{
    public static float budget;

    // Start is called before the first frame update
    void Start()
    {
        JobManager.OnJobChange += GetPayed;
        JobManager.OnJobChange += PaymentRateAdjuster;
    }
    //Payment
    private void GetPayed(JobsSO currentJob)
    {
        if (Callendar.actualDaysInAmounth==1&&currentJob.paycheckState.Equals(JobsSO.State.unpayed))
        {
            MounthlyPayment(currentJob);
            currentJob.paycheckState = JobsSO.State.gotPayed;
        }
        else if (Callendar.actualDaysInAmounth>1)
        {
            currentJob.paycheckState = JobsSO.State.unpayed;
        }
    }
    void MounthlyPayment(JobsSO currentJob)
    {
        budget += currentJob.monthlyPayment * currentJob.paymentRate;
    }
    void PaymentRateAdjuster(JobsSO currentJob)
    {
        currentJob.timeInJob += Time.deltaTime;
        float daysInJob = Mathf.RoundToInt(currentJob.timeInJob / Callendar.staticTimerPerDay);
        currentJob.paymentRate =0.5f+ Mathf.Clamp(daysInJob / currentJob.timeToExpertise
            , 0, currentJob.maxPayRate-0.5f);

    }

    //
}
