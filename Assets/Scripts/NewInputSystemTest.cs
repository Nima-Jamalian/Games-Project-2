using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemTest : MonoBehaviour
{
    [SerializeField] bool w, a, s, d;
    InputControls inputActions;

    private void Awake()
    {
        inputActions = new InputControls();
        inputActions.MovementActionInput.UpAction.started += onUpActionPressed;
        inputActions.MovementActionInput.UpAction.canceled += onUpActionPressed;
    }

    private void OnEnable()
    {
        inputActions.MovementActionInput.Enable();
    }

    private void OnDisable()
    {
        inputActions.MovementActionInput.Disable();
    }

    void onUpActionPressed(InputAction.CallbackContext callbackContext)
    {
        w = callbackContext.ReadValueAsButton();
    }

    // Update is called once per frame
    void Update()
    {
        //w = inputActions.MovementActionInput.UpAction.IsPressed();
        //s = inputActions.MovementActionInput.DownAction.IsPressed();
        //a = inputActions.MovementActionInput.LeftAction.IsPressed();
        //d = inputActions.MovementActionInput.RightAction.IsPressed();
    }
}
