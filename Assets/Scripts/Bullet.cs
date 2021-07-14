using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 50f;
    private Transform target;
    public GameObject impactEffect;
    public void Seek(Transform target)
    {
        this.target = target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(target.gameObject);
        Destroy(effectInstance, 2f);
        Destroy(gameObject);
    }
}
