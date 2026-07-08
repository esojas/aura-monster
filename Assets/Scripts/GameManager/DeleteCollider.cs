using UnityEngine;

public class DeleteCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.root.gameObject, 0.01f);
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
