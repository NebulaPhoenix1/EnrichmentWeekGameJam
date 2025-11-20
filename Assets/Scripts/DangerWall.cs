using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class DangerWall : MonoBehaviour
{
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 12f;
    [SerializeField] private float speedGainPerSec = 0.25f;
    private float currentSpeed;
    private float currentWait; 
    private Rigidbody2D rb;
    private DeathHandle deathMaster;
    [SerializeField] private InputActionAsset moveActionAsset;
    private InputAction moveAction;
    private bool move = false;
    void Start()
    {
        currentSpeed = minSpeed;
        rb = GetComponent<Rigidbody2D>();
        deathMaster = FindFirstObjectByType<DeathHandle>();
        moveAction = moveActionAsset.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            currentWait += Time.deltaTime;
            if(currentWait >= 1f && currentSpeed < maxSpeed)
            {
                currentWait = 0f;
                currentSpeed+= speedGainPerSec;
                rb.linearVelocity = new Vector2(currentSpeed, 0f);
            }       
        }
        else
        {
            Vector2 input = moveAction.ReadValue<Vector2>();
            if(input.magnitude > 0.1f)
            {
                move = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            deathMaster.Death();
        }
    }
}
