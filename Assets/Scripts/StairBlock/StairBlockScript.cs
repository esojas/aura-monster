using UnityEngine;


public class StairBlockScript : MonoBehaviour
{
    [Tooltip("How fast the stairs move straight down (units per second).")]
    [SerializeField] private float downwardSpeed = .1f;
    [SerializeField] private float backSpeed = .1f; // Has to be 10x of downward

    void Update()
    {
        MoveStair();
    }

    private void MoveStair()
    {
        transform.position += (Vector3.down * downwardSpeed * Time.deltaTime) + (Vector3.back * backSpeed * Time.deltaTime);
    }
}
