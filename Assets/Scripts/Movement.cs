using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpSpeed = 5f;
    private bool grounded = false;
    private Animator playerAnim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        grounded = true;
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get move action vector
        movementInput = moveAction.ReadValue<Vector2>();
        if(movementInput.x > 0) { playerAnim.SetBool("walking", true);}
        else if(movementInput.x == 0){ playerAnim.SetBool("walking", false);}
        //Horizontal Movement
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);
        //Jumping Logic
        if(grounded && movementInput.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, movementInput.y * jumpSpeed);
        }
    }

    public void SetGrounded(bool value)
    {
        grounded = value;
    }
    public bool GetGrounded()
    {
        return grounded;
    }
}
