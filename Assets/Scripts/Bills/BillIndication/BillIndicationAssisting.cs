using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BillIndicationAssisting : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler
{
    private BillIndication billIndicationParent;
    private Button thisButton;
    private void Awake()
    {
        billIndicationParent = GetComponentInParent<BillIndication>();
        thisButton = GetComponent<Button>();
    }
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        SelectBill();
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SelectBill();

    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
    private void SelectBill()
    {
        if (billIndicationParent.currentButton == null || !billIndicationParent.currentlyAbuttonIsSelected)
            this.billIndicationParent.currentButton = this.thisButton;
    }
    private void OnClick()
    {
        billIndicationParent.currentlyAbuttonIsSelected = true;
        this.billIndicationParent.currentButton = this.thisButton;
        //deselection happens through calls in button listeners
    }

}
