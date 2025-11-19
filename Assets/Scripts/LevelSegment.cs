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
        //Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("player left :(");
            playerInSegment = false;
            SegmentComplete.Invoke();
        }
        //Debug.Log("exit");
    }
}
