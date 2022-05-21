using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limbs : MonoBehaviour
{
    [SerializeField]
    private FloatValue pushForce;
    [SerializeField]
    private FloatValue jumpForce;
    [SerializeField]
    private FloatValue maxStaySpeed;
    [SerializeField]
    private Transform target;

    private Rigidbody2D rb;

    private Player player;

    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }

    private void FixedUpdate()
    {
        if (!player.stay) return;
        if (player.pushing)
        {
            Push();
        }
        if (player.jumping)
        {
            Jump();
        }

        speed = rb.velocity.magnitude;
    }

    private void Push()
    {
        rb.AddForce(target.right * pushForce.value, ForceMode2D.Impulse);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce.value, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(speed > maxStaySpeed.value)
        {
            player.stay = false;
        }
    }
}
