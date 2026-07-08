using UnityEngine;

public class MyPrefabController : MonoBehaviour
{
    public GameObject prefab;

    public string prefabName = "MyPrefab";

    // Use this for initialization
    void Start()
    {
        prefab = (GameObject)Resources.Load(prefabName);
    }
}
