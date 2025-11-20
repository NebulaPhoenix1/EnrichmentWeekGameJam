using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private DeathHandle deathHandle;

    // Update is called once per frame
    void Update()
    {
        //Move death plane to match player's X position
        float newX = playerTransform.position.x;
        transform.position = new Vector2(newX, transform.position.y);  
        deathHandle = FindFirstObjectByType<DeathHandle>();       
    }

    //Send player to main menu when they touch death plane
    public void OnTriggerEnter2D(Collider2D collision)
    {   
        //Check if player is touching death plane
        if(collision.gameObject.CompareTag("Player"))
        {
            deathHandle.Death();
        }
    }
}
