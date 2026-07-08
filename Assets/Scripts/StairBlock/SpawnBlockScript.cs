using UnityEngine;

public class SpawnBlockScript : MonoBehaviour
{
    public MyPrefabController prefabController;
    private GameObject stairBlockPrefab;
    public Transform nextSpawnLocation;
    private bool hasPassed = false;

    private void SpawnStairMethod()
    {
        if (stairBlockPrefab == null) return;
        Instantiate(stairBlockPrefab, nextSpawnLocation.position, Quaternion.identity);
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
        stairBlockPrefab = prefabController.prefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
