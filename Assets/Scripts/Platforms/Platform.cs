using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public float jumpForce = 100f;
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
        Destroy(this.gameObject);
    }
}