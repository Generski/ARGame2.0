using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private PlayerControls controls;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool canShoot = true;
    [SerializeField] private float fireRate;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Shoot.started += ctx => Shoot();
    }

    private void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(fireRate);

        canShoot = true;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void IncreaseFireRate()
    {
        fireRate = fireRate / 2;
    }
}
