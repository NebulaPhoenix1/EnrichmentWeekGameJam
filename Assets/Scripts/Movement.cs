using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private InputAction moveAction;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 2f;
    private bool grounded = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        grounded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get move action vector
        movementInput = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);
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
