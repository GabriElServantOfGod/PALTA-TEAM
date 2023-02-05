using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    [SerializeField] float speed = 700f; // speed of movement
    [SerializeField] float maxVelocity = 7500f; // maximum velocity of movement
    [SerializeField] float smoothing = 0.1f; // smoothing factor for velocity updates

    private Rigidbody rb;
    private Animator animator;
    private float cooldown = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        Vector3 movement = new Vector3();

        if (cooldown <= 0f)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movement += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement += Vector3.left;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movement += Vector3.back;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement += Vector3.right;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("isPlanting", true);
            cooldown = 1f;
        }

        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
            movement = Vector3.zero;
        }
        else
        {
            animator.SetBool("isPlanting", false);
        }

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            movement = movement.normalized * speed * Time.deltaTime;
            rb.velocity = Vector3.ClampMagnitude(movement, maxVelocity);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, smoothing);
            animator.SetBool("IsWalking", false);
        }
    }


}
