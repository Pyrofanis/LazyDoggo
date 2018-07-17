using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="billData",menuName ="LazzyDoggo/DataContainers/billData",order =3)]
public class BillsSO : ScriptableObject
{
  public enum billType
    {
        electricity,
        cable,
        telephony,
        water,
        taxes,
        rent,
        tuition,
        nothingSelected
    }
    public enum billState
    {
        payed,
        unpayed
    }

    [Header("Bill to be repaid")]
    public billType bill;
    [Header("The Cost of the bill")]
    [Range(20,1200)]
    public float cost;
    [Header("interest rate to increase per day")]
    [Range(1,4)]
    public float interestRate;
    [HideInInspector]
    public float previousInterestRate;
    [Header("Days gathered unpaid")]
    [Range(0,9999)]
    public float timeLeftUnpaid;
    [Header("State Of Bill")]
    public billState currentState;
}
