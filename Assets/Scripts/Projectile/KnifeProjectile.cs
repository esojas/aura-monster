using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    [SerializeField] private float knifeLifetime = 6f;

    private void KnifeLifetime()
    {
        if(knifeLifetime > 0) knifeLifetime -= Time.deltaTime;
        if (knifeLifetime <= 0)
        {
            Invoke(nameof(Destroy),.1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KnifeLifetime();
    }
}
