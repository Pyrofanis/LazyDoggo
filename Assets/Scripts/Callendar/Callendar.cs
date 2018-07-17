using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callendar : MonoBehaviour
{
    [Header("Time that a day Lasts")]
    [Range(0.01f, 2)]
    [SerializeField]
    private  float timerPerDay;

    public static int daysCollectivly;
    public static int actualDaysInAmounth;
    public static float staticTimerPerDay;

    private static int mounths;
    private static int initialYear;
    private static float yearlyTimer;
    private static float mounthlyTimer;
    private static float timer;
    // Start is called before the first frame update
    void Start()
    {
        initialYear = 2017;
        staticTimerPerDay = timerPerDay;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCallendar();
    }
    //calendar
    private void UpdateCallendar()
    {

        daysCollectivly = 1 + Mathf.RoundToInt(Timer() / timerPerDay);
        actualDaysInAmounth = 1 + Mathf.RoundToInt(mounthlyTimer / timerPerDay);
        MounthsCounter();
        YearsCounter();
    }
    public static int DaysInAMounth()
    {
        if (mounths==4||mounths==6||mounths==9||mounths==11)
        {
            return 30;
        }
        else if (mounths == 2)
        {
            return 28;
        }
        else
        {
            return 31;
        }
    }
    public static int MounthsCounter()
    { 
        if (actualDaysInAmounth.Equals(DaysInAMounth()))
        {
            mounthlyTimer = 0;
            mounths++;
        }
        else
        {
            mounthlyTimer += Time.deltaTime;
        }
        if (mounths > 12 || mounths == 0)
        {
            mounths = 1;
        }
        return mounths;
    }
    private static float Timer()
    {
        if (mounths <= 12)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        return timer;
    }
    public static  int YearsCounter()
    {
        yearlyTimer += Time.deltaTime;
        int daysCollectivly = Mathf.RoundToInt(yearlyTimer / staticTimerPerDay);
        return initialYear + Mathf.RoundToInt(daysCollectivly / 365);
    }
    //calendar
}


