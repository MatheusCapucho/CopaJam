using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-10)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private PlayerInput _playerInput;
    private InputAction _touchPressAction;
    private InputAction _touchPositionAction;

    public Action OnTouchPressed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        Setup();      

    }
    private void Setup()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPositionAction = _playerInput.actions["TouchPosition"];
        _touchPressAction = _playerInput.actions["TouchPress"];
    }
    private void OnEnable()
    {
       
        _touchPressAction.started += GetTouchPressed;
    }
    private void OnDisable()
    {
        
        _touchPressAction.started -= GetTouchPressed;
    }

    public void GetTouchPressed(InputAction.CallbackContext ctx) 
    {
        Vector2 position = _touchPositionAction.ReadValue<Vector2>();
        OnTouchPressed?.Invoke();
    }


}
