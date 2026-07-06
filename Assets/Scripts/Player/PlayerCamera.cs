using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float cameraSmooth = 2f;


    private void FollowPlayerCamera()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(0, playerPos.position.y + 6, -12), cameraSmooth * Time.deltaTime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayerCamera();
    }
}
