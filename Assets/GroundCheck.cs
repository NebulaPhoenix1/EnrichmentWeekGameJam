using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    private Collider2D groundCheckColldier;
    public UnityEvent grounded;
    public UnityEvent notGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundCheckColldier = GetComponent<BoxCollider2D>();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On Ground! (probably)");
        grounded.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Off Ground (probably)");
        notGrounded.Invoke();
    }
}
