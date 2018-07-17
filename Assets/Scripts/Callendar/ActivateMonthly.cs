using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMonthly : MonoBehaviour
{
    [SerializeField]
    [Header("GameObjectToActivate monthly")]
    private GameObject objectToActivate;

    // Update is called once per frame
    void Update()
    {
        if (Callendar.actualDaysInAmounth == 1)
        {
            objectToActivate.SetActive(true);
        }
    }
}
