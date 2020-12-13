using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int maxHealth = 3;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }

        Debug.Log("Enemy hit!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);

            if(dist <= 0.01f)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
