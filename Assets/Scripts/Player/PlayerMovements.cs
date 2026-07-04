using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float interpolateMovementSpeed = 0.5f;

    private Rigidbody rb;
    private PlayerControls playerControls;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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

        float targetX = movementSpeed * direction.x;
        float targetY = rb.linearVelocity.y;
        float targetZ = movementSpeed * direction.y;

        rb.linearVelocity = new Vector3(
            Mathf.Lerp(rb.linearVelocity.x, targetX, interpolateMovementSpeed),
            Mathf.Lerp(rb.linearVelocity.y, targetY, interpolateMovementSpeed),
            Mathf.Lerp(rb.linearVelocity.z, targetZ, interpolateMovementSpeed)
        );

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
}
