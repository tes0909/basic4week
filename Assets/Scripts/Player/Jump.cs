using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpPower = 200.0f;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }
    private void OnCollisionEnter(Collision collision)
    {

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
