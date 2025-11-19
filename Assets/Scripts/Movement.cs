using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveSpeedGainPerSec = 0.1f;
    [SerializeField] private float maxMoveSpeed = 10f;
    private float increaseSpeedTimer = 0f;
    [SerializeField] private float jumpSpeed = 5f;
    private Animator playerAnim;
    private GroundCheck groundCheck;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        groundCheck = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get move action vector
        movementInput = moveAction.ReadValue<Vector2>();
        //If moving
        if(movementInput.x > 0 || movementInput.x < 0) 
        { 
            playerAnim.SetBool("walking", true);
            //Increase speed/sec, to a cap
            increaseSpeedTimer+=Time.deltaTime;
            if(increaseSpeedTimer >= 1.0f && moveSpeed < maxMoveSpeed)
            {
                increaseSpeedTimer = 0;
                moveSpeed += moveSpeedGainPerSec;
            }
        }
        else if(movementInput.x == 0){ playerAnim.SetBool("walking", false);}
        //Horizontal Movement
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);
        //Jumping Logic
        if(groundCheck.CheckIfGrounded() && jumpAction.WasPressedThisFrame())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }   
    }
}
