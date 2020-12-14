using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 1f;

    private int damage = 1;

    private Transform playerPos;
    private Vector3 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z);

        Invoke("Destroy", 2f);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position == target)
        {
            Destroy();
        }
        //rb.MovePosition((transform.position + Vector3.forward) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
