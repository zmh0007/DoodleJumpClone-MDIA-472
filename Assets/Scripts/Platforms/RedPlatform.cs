using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    public LayerMask platformMask;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "RedPlatform")
        {
            transform.position += Vector3.up * 5;
            transform.position = new Vector3(Random.Range(-7f, 7f), transform.position.y, 0);
        }
    }
    private void OnBecameInvisible()
    {
        transform.position += Vector3.up * 5;
        transform.position = new Vector3(Random.Range(-7f, 7f), transform.position.y, 0);

        if (Physics.CheckSphere(transform.position, 1, platformMask))
        {
            transform.position += Vector3.up * (float)0.5;
        }
    }
}
