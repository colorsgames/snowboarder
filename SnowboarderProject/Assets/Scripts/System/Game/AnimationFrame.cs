using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFrame : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float lerpSpeed;

    private void FixedUpdate()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target.localRotation, lerpSpeed * Time.deltaTime);
    }
}
