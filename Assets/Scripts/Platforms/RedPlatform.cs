using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "RedPlatform")
        {
            transform.position += Vector3.up * 5;
            transform.position = new Vector3(Random.Range(-6f, 6f), transform.position.y, 0);
        }
    }
    private void OnBecameInvisible()
    {
        transform.position += Vector3.up * 5;
        transform.position = new Vector3(Random.Range(-6f, 6f), transform.position.y, 0);

    }
}
