using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PlatformTime());
    }

    IEnumerator PlatformTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
