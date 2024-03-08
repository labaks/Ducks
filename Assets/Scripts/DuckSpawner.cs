using System.Collections;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject GC;
    public int maxDuckCount = 5;
    public int duckOffset = 20, groundOffset = 100;
    public GameObject ducksHolder;
    
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
                int duckType = ChooseDuckType(DuckLibrary.duckRelativities);
                GameObject newDuck = Instantiate(gameController.duckPrefabs[duckType], RandomPosition(), Quaternion.identity, ducksHolder.transform);
                newDuck.GetComponent<DuckController>().gameController = gameController;
                newDuck.GetComponent<DuckController>().duckType = duckType;
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

    private int ChooseDuckType(float[] probs)
    {
        float total = 0;
        foreach (float elem in probs)
        {
            total += elem;
        }
        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint <= probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
