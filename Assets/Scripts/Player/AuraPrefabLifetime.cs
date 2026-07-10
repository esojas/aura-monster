using UnityEngine;

public class AuraPrefabLifetime : MonoBehaviour
{
    [SerializeField] private float prefabLifetime = .5f;

    private void DestroyItself()
    {
        Destroy(this.gameObject, prefabLifetime);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DestroyItself();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
