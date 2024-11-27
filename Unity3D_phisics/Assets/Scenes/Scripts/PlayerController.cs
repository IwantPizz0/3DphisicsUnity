using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;      
    [SerializeField] private float _rotationSpeed;   
    [SerializeField] private float _jumpForce;      
    [SerializeField] private KeyCode _jumpKey;
    // [SerializeField] private LayerMask _coinMask; 
    // [SerializeField] private Score playerScore; 
    private bool _isGrounded; 

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveForward = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        Move(moveForward);
        Rotate(rotate);

        if (Input.GetKeyDown(_jumpKey))
        {
            Jump();
        }
    }

    private void Move(float value)
    {
        //_rb.velocity = new Vector3(value, 0, 0).normalized;
        //_rb.velocity = transform.forward * value * _moveSpeed;
        _rb.MovePosition(transform.position + transform.forward * value * _moveSpeed * Time.deltaTime);
    }

    private void Rotate(float value)
    {
        Quaternion rotation = (Quaternion.Euler(0f, value * _rotationSpeed * Time.deltaTime, 0f));
        _rb.MoveRotation (_rb.rotation * rotation);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (LayerMaskUtil.ContainsLayer(_coinMask, other.gameObject.layer))
    //     {
    //         if (other.gameObject.TryGetComponent(out Coin coin))
    //         {
    //             playerScore.AddScore(coin.price);
    //             gameObject.SetActive(false);
    //         }
    //     }
    // }
}