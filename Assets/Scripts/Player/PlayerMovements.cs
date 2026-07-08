using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float interpolateMovementSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private MusicEvent musicEvent;

    private bool isInEventWindow = false;
    private CharacterController controller;
    private PlayerControls playerControls;
    private Vector2 direction;
    private Vector3 currentVelocity;
    private float verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = GetComponent<PlayerControls>();
    }

    private void OnEnable()
    {
        playerControls.OnMove += HandleDirection;
        playerControls.OnJumpPressed += HandleJump;
        musicEvent.GameStateChangeEvent += GameStateChange;
    }

    private void OnDisable()
    {
        playerControls.OnMove -= HandleDirection;
        playerControls.OnJumpPressed -= HandleJump;
        musicEvent.GameStateChangeEvent -= GameStateChange;
    }

    private void GameStateChange(bool state)
    {
        isInEventWindow = state;
    }

    private void HandleDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void HandleJump()
    {
        if (controller.isGrounded && isInEventWindow)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void HandleMovement()
    {
        Vector3 targetVelocity = isInEventWindow
        ? Vector3.zero 
        : new Vector3(direction.x, 0, direction.y) * movementSpeed;

        currentVelocity.x = Mathf.Lerp(currentVelocity.x, targetVelocity.x, interpolateMovementSpeed * Time.fixedDeltaTime);
        currentVelocity.z = Mathf.Lerp(currentVelocity.z, targetVelocity.z, interpolateMovementSpeed * Time.fixedDeltaTime);


        controller.Move(currentVelocity * Time.fixedDeltaTime);
    }

    private void Gravity()
    {
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.fixedDeltaTime;
        }

        currentVelocity.y = verticalVelocity;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Gravity();

        HandleMovement();
    }
}