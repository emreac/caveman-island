using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10; // Amount of damage the enemy deals
    public float attackRate = 1f; // Time between attacks in seconds
    private float nextAttackTime = 0f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}
