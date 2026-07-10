using UnityEngine;

public class PlayerAura : MonoBehaviour
{
    [SerializeField] private GameObject stepAura;
    public Transform RightFeetPos;
    public Transform LeftFeetPos;

    private void SpawnRightAuraSteps()
    {
        Instantiate(stepAura, RightFeetPos.position, stepAura.transform.rotation);
    }

    private void SpawnLeftAuraSteps()
    {
        Instantiate(stepAura, LeftFeetPos.position, stepAura.transform.rotation);
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
