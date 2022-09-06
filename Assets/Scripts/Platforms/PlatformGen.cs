using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    public GameObject platform;
    public GameObject Player;
    public int numberOfPlatforms = 0;
    public int platformsDeleted = 0;
    public float levelWidth = 3f;
    public float minY = .4f;
    public float MaxY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
       GeneratePlatforms();
    }
    public void GeneratePlatforms()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(Player.transform.localPosition.y + minY, Player.transform.localPosition.y + MaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            if (platform != null)
            {
                Instantiate(platform, spawnPosition, Quaternion.identity);
            }
        }
    }
}
