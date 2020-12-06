using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;

    private Rigidbody rb;

    [SerializeField] private float moveSpeed = 10f;
    private Vector2 move;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        move = controls.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
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
