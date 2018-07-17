using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSupport : MonoBehaviour
{
    [System.Serializable]
    public struct TWODimensionalButton
    {
        public Button[] x;
        public Button[] y;

        public TWODimensionalButton(Button[] newX, Button[] newY)
        {
            this.x = newX;
            this.y = newY;
        }
    }
    public enum Group
    {
        horizontal,
        vertical
    }

    [Header("Current buttons")]
    [SerializeField]
    private TWODimensionalButton currentPannelButtons;
    [Header("Type Of Menu")]
    [SerializeField]
    private Group group;
    [SerializeField]
    private Button[,] array;
    [Header("Escape button")]
    [Header("The Animator To Escape")]
    [SerializeField]
    private Animator animator;
    [Header("controller to enable")]
    [SerializeField]
    private ControllerSupport controller;

    private LazyDoggoInputs inputActions;
    [HideInInspector]
    public int x, y;
    private int xLength, initialX = 0, yLength, initialY = 0;

    private void Awake()
    {
        inputActions = new LazyDoggoInputs();
        array = new Button[currentPannelButtons.x.Length, 2];
        PrepToAddArrray();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions.Enable();
        AddToArray();
        SubscribeToInputs();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (enabled&&!GeneralSelectionOnMouseEnter.disableControlls)
            array[XClamped(), yClamped()].Select();
    }
    private void SubscribeToInputs()
    {
        inputActions.PcAndConsole.UpHorizontal.performed += _ => IncreaseHorizontal();
        inputActions.PcAndConsole.UpVertical.performed += _ => IncreaseVertical();
        inputActions.PcAndConsole.DownHorizontal.performed += _ => DecreaseHorizontal();
        inputActions.PcAndConsole.DownVertical.performed += _ => DecreaseVertical();
        inputActions.PcAndConsole.EscapeButton.performed += _ => Escape();
    }

    private void PrepToAddArrray()
    {
        xLength = currentPannelButtons.x.Length - 1;
        yLength = currentPannelButtons.y.Length - 1;
    }
    private void AddToArray()
    {
        while (xLength >= 0)
        {
            array[initialX, 0] = currentPannelButtons.x[xLength];
            xLength--;
            initialX++;
        }
        while (yLength >= 0)
        {
            array[initialY, 1] = currentPannelButtons.y[yLength];
            yLength--;
            initialY++;
        }

    }

    //clamping Virtual Vector
    private int XClamped()
    {
        if (x > currentPannelButtons.x.Length - 1)
        {
            x = currentPannelButtons.x.Length - 1;
        }
        else if (x < 0)
        {
            x = 0;
        }
        return x;
    }
    private int yClamped()
    {
        if (y > 1)
        {
            y = 1;
        }
        else if (y < 0)
        {
            y = 0;
        }
        return y;

    }
    //clamping Virtual Vector

    //button integer adjusters
    private void IncreaseHorizontal()
    {
        if (group.Equals(Group.horizontal))
            x++;
        else y++;
    }
    private void DecreaseHorizontal()
    {
        if (group.Equals(Group.horizontal))
            x--;
        else y--;
    }
    private void IncreaseVertical()
    {
        if (group.Equals(Group.horizontal))
            y++;
        else x++;
    }
    private void DecreaseVertical()
    {
        if (group.Equals(Group.horizontal))
            y--;
        else x--;
    }
    //button integer adjusters

    //Escape Button
    private void Escape()
    {
        if (animator != null)
        {
            animator.Play("OnMouseExit");
            controller.enabled = true;
            enabled = false;
        }
        else
        {
            Application.Quit();
        }
    }
    //Escape Button

}
