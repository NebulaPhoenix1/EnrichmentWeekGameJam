using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    private int highScore;
    private Transform playerTransform;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("high score:" + highScore);
        scoreText.text = "Score: " + score + "m";
        highscoreText.text = "High Score: " + highScore + "m";
    }

    // Update is called once per frame
    void Update()
    {
        //highscoreText.text = "High Score: " + score + "m";
        if(playerTransform.position.x > score)
        {
            score = (int)playerTransform.position.x;
            scoreText.text = "Score: " + score + "m";
            if(score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                highscoreText.text = "High Score: " + score + "m";
            }
        }
    }

    public int getScore()
    {
        return score;
    }
}
