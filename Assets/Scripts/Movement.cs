using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5;
    Vector3 direction = Vector3.zero;
    Vector2 inputVector = Vector2.zero;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(CallbackContext context)
    {
        
        inputVector = (context.ReadValue<Vector2>());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = new Vector3(inputVector.x, 0, inputVector.y) * speed;
        controller.SimpleMove(direction);
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);  
        }
    }
}
