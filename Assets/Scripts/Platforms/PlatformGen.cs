using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    public GameObject platform;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .4f;
    public float MaxY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, MaxY);
            spawnPosition.x = Random.Range(-levelWidth,levelWidth);
            Instantiate(platform, spawnPosition, Quaternion.identity);
        }
    }
}
