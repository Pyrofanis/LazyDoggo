using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    [Header("Doogy Animator")]
    [Tooltip("Add mascot that playes current animations")]
    [SerializeField]
    private Animator doogyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        JobManager.OnJobChange += ChangeAnimation;
    }

    void ChangeAnimation(JobsSO jobSo)
    {
        switch (jobSo.job)
        {
            case JobsSO.jobType.captain:
                doogyAnimator.SetBool("DrivingShip", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.electrician:
                doogyAnimator.SetBool("ElectricianWorking", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.Janitor:
                doogyAnimator.SetBool("JanitorWorking", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.delivery:
                doogyAnimator.SetBool("Deliverying", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.refuseCollector:
                doogyAnimator.SetBool("RefuseCollecting", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.programmer:
                doogyAnimator.SetBool("Programming", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.waiter:
                doogyAnimator.SetBool("Waitering", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.taxiDriver:
                doogyAnimator.SetBool("Driving", true);

                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false);
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.teacher:
                doogyAnimator.SetBool("Teaching", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("DrivingShip", false); 
                doogyAnimator.SetBool("idle", false);
                break;
            case JobsSO.jobType.unemployed:
                doogyAnimator.SetBool("idle", true);

                doogyAnimator.SetBool("Driving", false);
                doogyAnimator.SetBool("Deliverying", false);
                doogyAnimator.SetBool("Waitering", false);
                doogyAnimator.SetBool("Teaching", false);
                doogyAnimator.SetBool("ElectricianWorking", false);
                doogyAnimator.SetBool("JanitorWorking", false);
                doogyAnimator.SetBool("Programming", false);
                doogyAnimator.SetBool("RefuseCollecting", false);
                doogyAnimator.SetBool("DrivingShip", false);
                break;
        }
    }
}
