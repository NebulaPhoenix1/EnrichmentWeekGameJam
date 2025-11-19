using UnityEngine;
using UnityEngine.Events;

public class LevelSegment : MonoBehaviour
{
    public UnityEvent SegmentComplete;
    public int SegmentNumber = 0;

    private bool completed = false;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            completed = true;
            SegmentComplete.Invoke();
        }
        //Debug.Log("Enter");
    }
}
