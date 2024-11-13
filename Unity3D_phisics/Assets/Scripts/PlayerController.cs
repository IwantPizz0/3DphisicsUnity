using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode jumpKey;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveForward = Input.GetAxis("Vertical");
        float ratate = Input.GetAxis("Horizontal");

        Move(moveForward);
        Rotate(ratate);
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    private void Move(float value)
    {
        //Vector3 moveDir = new Vector3(0, _rb.velocity.y, value * moveSpeed);
        //_rb.velocity = moveDir;
        _rb.velocity = transform.forward * value * moveSpeed;
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Rotate(float value)
    {
        transform.Rotate(Vector3.up, value * rotationSpeed * Time.deltaTime);
    }
}

