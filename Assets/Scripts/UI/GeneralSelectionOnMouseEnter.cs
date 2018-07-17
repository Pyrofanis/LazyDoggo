using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GeneralSelectionOnMouseEnter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public static bool disableControlls;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        disableControlls = true;
        button.Select();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        disableControlls = false;
    }

}
