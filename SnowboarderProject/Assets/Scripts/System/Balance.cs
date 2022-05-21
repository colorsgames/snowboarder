using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField]
    private FloatValue restAngle;
    [SerializeField]
    private FloatValue balanceForce;
    [SerializeField]
    private Transform target;

    private Rigidbody2D rb;

    private Player player;

    float lerpSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }

    private void FixedUpdate()
    {
        if(!player.stay) { lerpSpeed = 0; return; }
        lerpSpeed += Time.deltaTime * 0.5f;
        if(lerpSpeed > balanceForce.value)
        {
            lerpSpeed = balanceForce.value;
        }
        if (target)
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, target.eulerAngles.z, lerpSpeed));
        }
        else
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, restAngle.value, lerpSpeed));
        }
    }
}
