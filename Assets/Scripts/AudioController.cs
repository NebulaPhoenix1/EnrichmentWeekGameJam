using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource highscore;

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayHighscoreSound()
    {
        highscore.Play();
    }
}
