using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputActionAsset inputActions;

    public event Action<Vector2> OnMove;
    public event Action OnAttackPressed;
    public event Action OnAttackReleased;

    private InputAction moveAction;
    private InputAction attackAction;

    private Action<InputAction.CallbackContext> onMovePerformed;
    private Action<InputAction.CallbackContext> onMoveCancelled;
    private Action<InputAction.CallbackContext> onAttackPerformed;
    private Action<InputAction.CallbackContext> onAttackCancelled;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");


        onMovePerformed = ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        onMoveCancelled = ctx => OnMove?.Invoke(Vector2.zero);

        onAttackPerformed = ctx => OnAttackPressed?.Invoke();
        onAttackCancelled = ctx => OnAttackReleased?.Invoke();
    }

    private void OnEnable()
    {
        moveAction.performed += onMovePerformed;
        moveAction.canceled += onMoveCancelled;
        attackAction.performed += onAttackPerformed;
        attackAction.canceled += onAttackCancelled;
    }

    private void OnDisable()
    {
        moveAction.performed -= onMovePerformed;
        moveAction.canceled -= onMoveCancelled;
        attackAction.performed -= onAttackPerformed;
        attackAction.canceled -= onAttackCancelled;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
