using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    private float maxCarPos = 3.8f;
    private Vector3 carPos;
    private float delayTime = 1f;
    private float timeSpawn;
    private int carOrder;
    private int score;
    private bool gameover;
    public static GameController gc;

    private void Awake()
    {
        gc = this;
    }

    void Start()
    {
        timeSpawn = 1f;
        UIManager.ui.SetScoreText($"Score: {score}");
        InvokeRepeating("ScoreIncrement", 0.5f, 0.5f);
    }

    void Update()
    {
        if (gameover)
        {
            timeSpawn = 0;
            UIManager.ui.ShowGameoverPanel(true);
            return;
        }

        timeSpawn -= Time.deltaTime;
        if (timeSpawn <= 0)
        {
            carPos = new Vector2(Random.Range(-maxCarPos, maxCarPos), 7f);
            carOrder = Random.Range(0, cars.Length);
            Instantiate(cars[carOrder], carPos, Quaternion.identity);
            timeSpawn = delayTime;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ScoreIncrement()
    {
        if (!gameover)
        {
            score++;
            UIManager.ui.SetScoreText($"Score: {score}");
        }
    }

    public void SetGameoverState(bool state)
    {
        gameover = state;
    }

    public bool Gameover()
    {
        return gameover;
    }
}
