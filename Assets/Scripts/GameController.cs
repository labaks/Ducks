using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text coinsCounterText, timeText;
    public GameObject gameOverPanel;
    public Text ducksCount_gop, coinsCount_gop;
    public float defaultTime = 60, timeRemaining, coinsCounter = 0f;
    public bool timerIsRunning = false, gameOver = false;
    public int ducksCounter = 0;

    public GameObject ducksSpawner;
    public GameObject[] duckPrefabs;

    PlayerStats stats;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        stats = GetComponent<PlayerStats>();
    }
    void Start()
    {
        timerIsRunning = true;
        timeRemaining = defaultTime;
    }
    void Update()
    {
        coinsCounterText.text = stats.moneyCount.ToString();
        Timer();
        if (gameOver)
        {
            DisplayGameOverPanel();
        }
    }

    void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                gameOver = true;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void CountDuck(float duckPrice)
    {
        ducksCounter++;
        coinsCounter += duckPrice;
        stats.moneyCount += duckPrice;
        float money = Mathf.Round(stats.moneyCount * 10.0f) * 0.1f;
        stats.moneyCount = money;
    }

    void DisplayGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        ducksCount_gop.text = ducksCounter.ToString();
        coinsCount_gop.text = coinsCounter.ToString();
        stats.SaveMoney();
    }

    public void Restart()
    {
        gameOver = false;
        gameOverPanel.SetActive(false);
        timeRemaining = defaultTime;
        timerIsRunning = true;
        coinsCounter = 0f;
        ducksCounter = 0;
        StartCoroutine(ducksSpawner.GetComponent<DuckSpawner>().spawnDuck());
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
