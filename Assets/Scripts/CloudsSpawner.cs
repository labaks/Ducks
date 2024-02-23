using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public int maxCloudsCount = 4;
    public GameObject cloudPrefab;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
        StartCoroutine(spawnCloud());
    }

    public IEnumerator spawnCloud()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (transform.childCount < maxCloudsCount)
            {
                GameObject newCloud = Instantiate(cloudPrefab, RandomPosition(), Quaternion.identity, transform);
                // newCloud.transform;
            }

        }
    }

    private Vector2 RandomPosition()
    {
        return new Vector2(camera.ScreenToWorldPoint(new Vector2(0, 0)).x - 25,
            UnityEngine.Random.Range(
                camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 18,
                camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 9)
        );
    }
}
