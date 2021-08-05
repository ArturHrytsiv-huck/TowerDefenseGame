using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float startHealth = 100;
    [SerializeField] private int worth = 30;
    

    [HideInInspector] public float speed = 10f;

    public float startSpeed = 10f;
    public GameObject deatheffect;

    [SerializeField] private Image healthBar;
    private float health;
    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
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
