using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JobsIndicAssisting : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,ISelectHandler
{
    private JobIndicator jobIndicatorParent;
    private Button thisButton;
    private void Awake()
    {
        jobIndicatorParent = GetComponentInParent<JobIndicator>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnButtonPressed);
    }
   //need to add a variable if this button is selected to do what onPointerEnter does
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SelectJob();
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OnButtonPressed();
    }
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        SelectJob();
    }

    private void SelectJob()
    {
        if (jobIndicatorParent.currentButton == null || !jobIndicatorParent.buttonCurrentlySelected)
            jobIndicatorParent.currentButton = thisButton;
    }
    private void OnButtonPressed()
    {
        jobIndicatorParent.buttonCurrentlySelected = true;
        jobIndicatorParent.currentButton = thisButton;
        //DESELECTED VIA BUTTON LISTENERS
    }
}
