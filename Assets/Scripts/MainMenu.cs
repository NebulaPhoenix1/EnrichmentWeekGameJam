using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highscore;
    [SerializeField] private TMP_Text previousScore;

    private PreviousScoreHolder previous;

    void Start()
    {
        previous = FindFirstObjectByType<PreviousScoreHolder>();
        SetHighScoreText();
        SetPreviousScoreText();
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetHighScoreText()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore") + "m";
    }

    public void SetPreviousScoreText()
    {
        previousScore.text = "Previous: " + previous.getPreviousScore() + "m";
    }
}
