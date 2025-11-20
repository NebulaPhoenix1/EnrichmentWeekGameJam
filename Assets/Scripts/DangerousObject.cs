using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DangerousObject : MonoBehaviour
{
    private DeathHandle deathHandle;
    void Start()
    {
        deathHandle = FindFirstObjectByType<DeathHandle>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            deathHandle.Death();
        }
    }
}
