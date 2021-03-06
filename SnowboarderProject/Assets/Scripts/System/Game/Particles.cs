using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
