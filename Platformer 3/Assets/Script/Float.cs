using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    private Rigidbody rb;

    public float force = 1f;
    public float targetHeight = 1f;
    public float dampenForce = 4f;
    public float maxdampen = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < targetHeight * 1.5f)
        {
            var distance = targetHeight - transform.position.y;
            var f = distance * force - Mathf.Clamp(rb.velocity.y * dampenForce, -maxdampen, maxdampen);
            Debug.Log(distance);
            rb.AddForce(new Vector3(0, f, 0));
        }
    }
}
