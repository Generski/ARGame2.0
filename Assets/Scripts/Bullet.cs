using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 1f;

    private int damage = 1;

    private Transform targetPos;
    private Vector3 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        Invoke("Destroy", 2f);

        targetPos = GameObject.FindGameObjectWithTag("Enemy").transform;

        target = new Vector3(targetPos.position.x, targetPos.position.y, targetPos.position.z);
    }

    private void FixedUpdate()
    {
        if(targetPos == null || target == null)
        {
            Debug.Log("No target");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position == target)
            {
                Destroy();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);

            if (dist < 0.01f)
            {
                other.GetComponent<EnemyHealth>().TakeDamage(damage);
                Destroy();
            }
        }
        else
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
