using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFrame : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void FixedUpdate()
    {
        transform.localRotation = target.localRotation;
    }
}
