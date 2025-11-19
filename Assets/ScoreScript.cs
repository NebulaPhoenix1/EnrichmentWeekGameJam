using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    private int highScore;
    private Transform playerTransform;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        highScore = PlayerPrefs.GetInt("HighScore");
        scoreText.text = "Score: " + score + "m";
        highscoreText.text = "High Score: " + highScore + "m";
    }

    // Update is called once per frame
    void Update()
    {
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
}
