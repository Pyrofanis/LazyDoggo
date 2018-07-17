using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    [Header("Goal Slider")]
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Button buyHouseButton;

    [Header("The cost oof the house")]
    [SerializeField]
    private float housesValues;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = housesValues;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliderValue();
        EnableBuyButton();
    }
    private void UpdateSliderValue()
    {
        slider.value = Mathf.Clamp(PaymentScedule.budget - BillsSchedule.billsSum, 0, housesValues);
    }
    private void EnableBuyButton()
    {
        if (PaymentScedule.budget >= housesValues && BillsSchedule.billsSum == 0)
            buyHouseButton.gameObject.SetActive(true);
        else buyHouseButton.gameObject.SetActive(false);

    }
}
