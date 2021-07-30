using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private int worth = 30;
    

    [HideInInspector] public float speed = 10f;

    public float startSpeed = 10f;
    public GameObject deatheffect;

    private void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.money += worth;
        GameObject effect = (GameObject)Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        Destroy(gameObject);
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
