using UnityEngine;
using UnityEngine.Events;

public class LevelSegment : MonoBehaviour
{
    private bool playerInSegment = false;
    public UnityEvent SegmentComplete;
    public int SegmentNumber = 0;

    void Start()
    {
        
    }

    public bool GetIsPlayerInsideSegment()
    {
        return playerInSegment;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInSegment = true;
        }
    }

    private void OExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInSegment = false;
            SegmentComplete.Invoke();
        }
    }
}
