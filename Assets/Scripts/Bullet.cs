using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 1f;

    private int damage = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("Destroy", 2f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
