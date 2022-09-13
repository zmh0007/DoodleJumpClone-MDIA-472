using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    public float jumpForce = 150f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "RedPlatform")
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        transform.position += Vector3.up * 5;
        transform.position = new Vector3(Random.Range(-5f, 5f), transform.position.y, 0);

    }
}
