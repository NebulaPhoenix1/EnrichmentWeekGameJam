using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandle : MonoBehaviour
{
    private ScoreScript score;
    private PreviousScoreHolder previousScore;
    public void Death()
    {
        score = FindFirstObjectByType<ScoreScript>();
        previousScore = FindFirstObjectByType<PreviousScoreHolder>();
        previousScore.setPreviousScore(score.getScore());
        SceneManager.LoadScene("NotAMainMenu");
    }
}
