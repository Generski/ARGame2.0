using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    private Transform player;

    private bool playerInShootingRange = false;

    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool canShoot = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        Vector3 direction = player.position - transform.position;

        Vector3 moveDirection = new Vector3(direction.x, transform.position.y, direction.z);

        transform.LookAt(player);

        if (!playerInShootingRange)
            rb.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));

        else if (playerInShootingRange)
        {
            if (canShoot)
            {
                Shoot();
            }
        }

    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(2f);

        canShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInShootingRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInShootingRange = false;
        }
    }
}
