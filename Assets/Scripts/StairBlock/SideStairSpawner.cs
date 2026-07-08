using UnityEngine;

public class SideStairSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sideStairBlockPrefab;
    public Transform nextSpawnLocation;
    private bool hasPassed = false;

    private void SpawnStairMethod()
    {
        if (sideStairBlockPrefab == null) return;
        Instantiate(sideStairBlockPrefab, nextSpawnLocation.position, Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.layer == 3 || other.gameObject.layer == 9) && !hasPassed)
        {
            Debug.Log("Object exited");
            SpawnStairMethod();
            hasPassed = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
}
