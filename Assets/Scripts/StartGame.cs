using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
	public int maxScore;
	public Text maxScoreText;

    public void OnStartGame(string sceneName)
    {
    	SceneManager.LoadScene(sceneName);
    }

    void Start()
    {
    	maxScore = PlayerPrefs.GetInt("maxScore");
    	maxScoreText.text = "历史最高分：" + maxScore;

    }
}
