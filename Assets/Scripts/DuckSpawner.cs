using System.Collections;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject GC;
    public int maxDuckCount = 5;
    public int duckOffset = 20, groundOffset = 100;
    public GameObject ducksHolder;
    public GameObject duckPrefab;

    private Camera camera;
    private GameController gameController;
    void Start()
    {
        camera = Camera.main;
        gameController = GC.GetComponent<GameController>();
        StartCoroutine(spawnDuck());
    }

    public IEnumerator spawnDuck()
    {
        while (!gameController.gameOver)
        {
            yield return new WaitForSeconds(3f);
            if (ducksHolder.transform.childCount < maxDuckCount)
            {
                GameObject newDuck = Instantiate(duckPrefab, RandomPosition(), Quaternion.identity, ducksHolder.transform);
                newDuck.GetComponent<DuckController>().gameController = gameController;
            }
        }
    }

    private Vector2 RandomPosition()
    {
        return new Vector2(
            UnityEngine.Random.Range(
                camera.ScreenToWorldPoint(new Vector2(0, 0)).x + duckOffset,
                camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - duckOffset),
            UnityEngine.Random.Range(
                camera.ScreenToWorldPoint(new Vector2(0, 0)).y + duckOffset,
                camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - duckOffset)
        );
    }
}
