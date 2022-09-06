using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public float jumpForce = 120f;
    public PlatformGen generation;
    public GameObject Death;
    public GameObject Player;

    private void Awake()
    {
        Death = GameObject.Find("PlatformDestroyer");
        Player = GameObject.Find("Player");
        generation = GetComponent<PlatformGen>();
    }

    private void Update()
    {
        if (transform.position.y < Death.transform.position.y)
        {
            generation.platformsDeleted++;
            Destroy(gameObject);
        }

        if(generation.platformsDeleted >= (generation.numberOfPlatforms/4))
        {
            generation.platformsDeleted = 0;
            generation.GeneratePlatforms();
        }
    }

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
        // Distance between camera and platform
}