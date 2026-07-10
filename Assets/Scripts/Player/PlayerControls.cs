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
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action OnPausePressed;

    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction jumpAction;
    private InputAction pauseAction;

    private Action<InputAction.CallbackContext> onMovePerformed;
    private Action<InputAction.CallbackContext> onMoveCancelled;
    private Action<InputAction.CallbackContext> onAttackPerformed;
    private Action<InputAction.CallbackContext> onAttackCancelled;
    private Action<InputAction.CallbackContext> onJumpPerformed;
    private Action<InputAction.CallbackContext> onJumpCancelled;
    private Action<InputAction.CallbackContext> onPausePerformed;


    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        jumpAction = InputSystem.actions.FindAction("Jump");
        pauseAction = InputSystem.actions.FindAction("PausedButton");

        onMovePerformed = ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        onMoveCancelled = ctx => OnMove?.Invoke(Vector2.zero);

        onJumpPerformed = ctx => OnJumpPressed?.Invoke();
        onJumpCancelled = ctx => OnJumpReleased?.Invoke();

        onAttackPerformed = ctx => OnAttackPressed?.Invoke();
        onAttackCancelled = ctx => OnAttackReleased?.Invoke();

        onPausePerformed = ctx => OnPausePressed?.Invoke();
    }

    private void OnEnable()
    {
        moveAction.performed += onMovePerformed;
        moveAction.canceled += onMoveCancelled;
        attackAction.performed += onAttackPerformed;
        attackAction.canceled += onAttackCancelled;
        jumpAction.performed += onJumpPerformed;
        jumpAction.canceled += onJumpCancelled;
        pauseAction.performed += onPausePerformed;
    }

    private void OnDisable()
    {
        moveAction.performed -= onMovePerformed;
        moveAction.canceled -= onMoveCancelled;
        attackAction.performed -= onAttackPerformed;
        attackAction.canceled -= onAttackCancelled;
        jumpAction.performed -= onJumpPerformed;
        jumpAction.canceled -= onJumpCancelled;
        pauseAction.performed -= onPausePerformed;
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
