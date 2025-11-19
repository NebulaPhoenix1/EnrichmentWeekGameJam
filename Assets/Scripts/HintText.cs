using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;

public class HintText : MonoBehaviour
{
    private TMP_Text hintText;
    private bool display = true;
    [SerializeField] private InputActionAsset moveActionAsset;
    private InputAction moveAction;
    [SerializeField] private string controllerMessage;
    [SerializeField] private string keyboardMessage;
    [SerializeField] private float flashSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hintText = GetComponent<TMP_Text>();
        //Check what input device we're using and set text message accordingly
        if(Gamepad.current != null) { hintText.text = controllerMessage; }
        else {hintText.text = keyboardMessage;}
        moveAction = moveActionAsset.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if(display)
        {
            //Slowly increase/decrease alpha of color on text to make it flash
            float alpha = Mathf.PingPong(Time.time * flashSpeed, 1.0f);
            alpha = Mathf.Clamp(alpha, 0.2f, 1);
            hintText.color = new Color(hintText.color.r, hintText.color.g, hintText.color.b, alpha);
            //Check if moveAction is inputted and if so display = false
            Vector2 input = moveAction.ReadValue<Vector2>();
            if(input.magnitude > 0.1f)
            {
                display = false;
                hintText.enabled = false;
            }
        }
    }
}
