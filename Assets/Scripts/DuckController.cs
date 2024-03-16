using System;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    private Camera camera;

    public GameController gameController;

    public ParticleSystem featherExplode;
    public GameObject effectsHolder;
    public int duckType;
    public String duckName;
    public float moveSpeed = 2f, duckPrice = 1f;
    public float directionX, directionY;
    public float minDir = -1f, maxDir = 1f;
    public int duckOffset = 20, groundOffset = 100, cloudsOffset = 60;
    PlayerStats stats;

    void Awake()
    {
        camera = Camera.main;
        effectsHolder = transform.parent.parent.Find("EffectsHolder").gameObject;
    }
    void Start()
    {
        stats = gameController.GetComponent<PlayerStats>();
        duckName = DuckLibrary.ducksNames[duckType];
        if (stats.duckLevels[duckType] == -1)
        {
            duckPrice = DuckLibrary.Duck_Prices[duckType, 0];
        }
        else
        {
            duckPrice = DuckLibrary.Duck_Prices[duckType, stats.duckLevels[duckType]];
        }
        directionX = RandomDirection();
        directionY = RandomDirection();
        if (directionX > 0) FlipDuck();
    }

    private void FixedUpdate()
    {
        transform.Translate(directionX * moveSpeed * Time.deltaTime, directionY * moveSpeed * Time.deltaTime, 0);
        PreventDuckGoingOffScreen();
    }

    private void PreventDuckGoingOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < duckOffset || screenPosition.x > camera.pixelWidth - duckOffset)
        {
            directionX = -directionX;
            FlipDuck();
        }
        if (screenPosition.y < duckOffset + groundOffset || screenPosition.y > camera.pixelHeight - duckOffset - cloudsOffset)
        {
            directionY = -directionY;
        }
    }

    void OnMouseDown()
    {
        if (!gameController.gameOver)
        {
            Instantiate(featherExplode, transform.position, Quaternion.identity, effectsHolder.transform);
            DestroyDuck();
        }
    }

    public void DestroyDuck()
    {
        gameController.CountDuck(duckPrice);
        Destroy(gameObject);
    }

    private void FlipDuck()
    {
        transform.localScale = new Vector3(-1f * transform.localScale.x, 1f, 1f);
    }
    private float RandomDirection()
    {
        var dir = UnityEngine.Random.Range(minDir, maxDir);
        return (float)Math.Round(dir, 3);
    }
}
