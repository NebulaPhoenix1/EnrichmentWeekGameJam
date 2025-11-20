using UnityEditor.VersionControl;
using UnityEngine;

public class PreviousScoreHolder : MonoBehaviour
{
    private int previousScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int getPreviousScore()
    {
        return previousScore;
    }

    public void setPreviousScore(int prev)
    {
        previousScore = prev;
    }
}
