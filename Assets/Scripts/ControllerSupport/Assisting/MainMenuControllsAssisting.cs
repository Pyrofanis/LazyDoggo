using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControllsAssisting : MonoBehaviour
{
    //this script is made to assist players and not get confused by the invisible button
    [Header("BuyHouseButton")]
    [SerializeField]
    private GameObject objectToCheckIfActive;
    private ControllerSupport mainPanelControllerSupport;
    // Start is called before the first frame update
    void Start()
    {
        mainPanelControllerSupport = GetComponent<ControllerSupport>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!objectToCheckIfActive.activeInHierarchy)
            mainPanelControllerSupport.y = 1;
    }
}
