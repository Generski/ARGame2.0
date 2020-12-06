using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private PlayerControls controls;
    public Transform firePoint;
    public GameObject bulletPrefab;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Shoot.started += ctx => Shoot();
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
