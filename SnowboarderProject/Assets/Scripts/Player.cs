using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public bool pushing;
    [HideInInspector]
    public bool jumping;

    public bool StartPushing { get; set; }
    public bool StartJumping { get; set; }
    public bool stay { get; set; } = true;

    [SerializeField]
    private float relaxingTime;
    [SerializeField]
    private float pushindDelay;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private LayerMask ground;

    private float curretRelaxingTime;
    private float curretPuhingDelayTime;

    private void Start()
    {
        curretPuhingDelayTime = pushindDelay;
    }

    private void Update()
    {
        
        if (!stay)
        {
            curretRelaxingTime += Time.deltaTime;
            if (curretRelaxingTime > relaxingTime)
            {
                stay = true;
                curretRelaxingTime = 0;
            }
        }
        
        curretPuhingDelayTime += Time.deltaTime;
        if (StartPushing)
        {
            if (curretPuhingDelayTime > pushindDelay)
            {
                pushing = true;
                curretPuhingDelayTime = 0;
            }
        }

        if (StartJumping && GroundCheck())
        {
            jumping = true;
        }
    }

    private void FixedUpdate()
    {
        pushing = false;
        jumping = false;

        StartPushing = false;
        StartJumping = false;
    }

    bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDistance, ground);
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * rayDistance);
    }
}
