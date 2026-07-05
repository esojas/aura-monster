using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float interpolateMovementSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;

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
    }

    private void OnDisable()
    {
        playerControls.OnMove -= HandleDirection;
    }

    private void HandleDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void HandleMovement()
    {
        Vector3 targetVelocity = new Vector3(direction.x, 0, direction.y) * movementSpeed;

        currentVelocity.x = Mathf.Lerp(currentVelocity.x, targetVelocity.x, interpolateMovementSpeed * Time.fixedDeltaTime);
        currentVelocity.z = Mathf.Lerp(currentVelocity.z, targetVelocity.z, interpolateMovementSpeed * Time.fixedDeltaTime);

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // small downward force to keep grounded flag reliable
        }
        else
        {
            verticalVelocity += gravity * Time.fixedDeltaTime;
        }

        currentVelocity.y = verticalVelocity;

        controller.Move(currentVelocity * Time.fixedDeltaTime);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
}