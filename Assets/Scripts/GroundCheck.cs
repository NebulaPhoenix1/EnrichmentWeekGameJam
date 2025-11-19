using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 boxcastOffset;
    [SerializeField] Vector2 boxcastSize = new Vector2(0.1f, 0.5f);

    public bool CheckIfGrounded()
    {
        //Do a boxcast below the players
        //It will return all the colliders within it
        //If any are tagged ground, return true else false
        Vector2 currentPosition = transform.position;
        bool grounded = Physics2D.BoxCast((currentPosition + boxcastOffset), boxcastSize, 0, Vector2.down, 1, groundLayer);
        Debug.Log(grounded);
        return grounded;
    }



}
