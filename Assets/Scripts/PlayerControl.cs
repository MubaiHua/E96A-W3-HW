using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    // properties of RigidBody, add Force, velocity
    Rigidbody rb;
    [SerializeField] GameObject bullet;
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float bulletSpeed = 100f;
    [SerializeField]
    float jumpHeight = 5f;
    bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        onGround = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value) // control type is vector 2 -> (x, y)
    {
        Vector2 input = value.Get<Vector2>();
        Debug.Log(input);

        // transform .position, transform.rotation, transform.fowared, transform.right
        rb.velocity = input.y * transform.forward + input.x * transform.right;
        rb.velocity *= speed;
    }

    void OnFire() // this action will be called when fire action is triggered
    {
        Debug.Log("Fire");

        GameObject bulletInstance = Instantiate(bullet, transform.position + 1f * transform.forward, Quaternion.identity);
        Rigidbody bulletRigidBody = bulletInstance.GetComponent<Rigidbody>();

        bulletRigidBody.AddForce(bulletSpeed * transform.forward);
    }

    void OnJump() //this action will be called when jump action is triggered
    {
        if (onGround)
        {
            rb.velocity = Vector3.up * jumpHeight;
        }
        else
        {
            return;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
