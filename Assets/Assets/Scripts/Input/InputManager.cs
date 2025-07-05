using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    private InputAction _touchPositionAction;
    private InputAction _touchPressAction;

    public static readonly UnityEvent<RaycastHit2D> LevelTouch = new UnityEvent<RaycastHit2D>();

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPressAction = _playerInput.actions["TouchPress"];
        _touchPositionAction = _playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
    }
    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector3 screenPos = _touchPositionAction.ReadValue<Vector2>();
        Vector3 position = Camera.main.ScreenToWorldPoint(screenPos);
        position.z = 0;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
       
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        //Debug.Log(hit.transform.gameObject.layer);
        
        //Проверка на то, что Клик был не по UI
        LevelTouch.Invoke(hit);
    }
}

