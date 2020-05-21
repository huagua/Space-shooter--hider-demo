using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Vector3 spawnValues;
	// public GameObject[] hazards;
    public GameObject originPeople;
    
    private int numPerWave = 15;
    private float spawnWait = 0.8f;    //小行星间隔时间
    private float startWait = 1.5f;    // 初始等待时间
    private float wavesWait = 3f;    //每波小行星等待时间

    public Text scoreText;
    public Text gameOverText;
    public Text finalScoreText;
    public Text finalScore;

    public Button restartButton;
    public Button menuButton;
    public Button pauseButton;
    public Button startButton;

    public static int score;

    public bool gameOver;

    public void RestartGame(string sceneName )
    {
        // SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(sceneName);
    }

    public void OnPauseGame()
    {
    	Time.timeScale = 0;
    	startButton.gameObject.SetActive(true);
    	pauseButton.gameObject.SetActive(false);
    }

    public void OnStartGame()
    {
    	Time.timeScale = 1;
    	startButton.gameObject.SetActive(false);
    	pauseButton.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Let's get starting :");
        StartCoroutine(SpawnWaves());
        resetData();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Random.value < 0.01 ) Spawn();
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            // Application.LoadLevel(Application.loadedLevel); 已过时

            SceneManager.LoadScene("SampleScene");
        }

    }

    // resetData() 初始化数据
    private void resetData()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        gameOverText.text = "";
        finalScoreText.text = "";
        finalScore.text = "";
        gameOver = false;
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    // SpawnWaves 批量产生小行星, 一批10个，循环产生
    IEnumerator SpawnWaves() 
    {
        yield return new WaitForSeconds(startWait);
        while(!gameOver) 
        {
            for(int i = 0; i < numPerWave; i++)
            {
                Spawn();
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavesWait);
        }
        
    }

    // Spawn 产生三种小行星中的任意一种
    void Spawn()
    {
    	// GameObject o = hazards[Random.Range(0, hazards.Length)];
    	Vector3 p = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
    	Quaternion q = Quaternion.identity;
    	Instantiate(originPeople, p, q);
    }

    // AddScore 计分函数
    public void AddScore (int v) 
    {
        score += v;
        scoreText.text = "Score: " + score;
    }

    // GameOver 游戏结束后需要进行的操作
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over!";
        finalScoreText.text = "Score";
        finalScore.text = "" + score;
        scoreText.text = "";
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        SaveData();
    }

    private void SaveData()
    {
        int tmp = PlayerPrefs.GetInt("maxScore");
        if(tmp < score){
            PlayerPrefs.SetInt("maxScore", score);
        }
    }
}
