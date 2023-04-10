using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public float jumpForce = 150f;
    public LayerMask platformMask;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
    private void OnBecameInvisible()
    {
        transform.position += Vector3.up * 5;
        transform.position = new Vector3(Random.Range(-7.5f,7.5f),transform.position.y,0);

        if (Physics.CheckSphere(transform.position,1, platformMask))
        {
            transform.position += Vector3.up * (float) 0.5;
        }
       
    }
}