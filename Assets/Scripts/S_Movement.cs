using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Movement : MonoBehaviour
{

    // Hold the left stick move input action
    public InputActionProperty MoveInputAction;

    // Hold the right stick rotate input action
    public InputActionProperty RotateInputAction;

    // Hold the transform component of the XR camera rig
    private Transform TransformComponent;

    // Hold the move speed of the character
    private float MoveSpeed = 5.0f;

    // Hold the rotate speed of the character
    private float RotationSpeed = 90.0f;

    /*
     * @brief On start set the components
     * @param none
     * @return none
     */
    void Start()
    {

        // Set the transform component
        TransformComponent = GetComponent<Transform>();

        // Return
        return;
    }

    /*
     * @brief On every frame listen for the inputs
     * @param none
     * @return void
     */
    void Update()
    {

        // Hold the value from the move input
        Vector2 MoveVector = MoveInputAction.action.ReadValue<Vector2>() * (MoveSpeed * Time.deltaTime);

        // Move the XR camera origin along its forward direction
        TransformComponent.position += TransformComponent.forward * MoveVector.y + TransformComponent.right * MoveVector.x;

        // Hold the value from the rotate input
        Vector2 RotateVector = RotateInputAction.action.ReadValue<Vector2>() * (RotationSpeed * Time.deltaTime);

        // Rotate the camera origin (Placeholder, you need to implement your own rotation logic)
        TransformComponent.rotation *= Quaternion.Euler(0f, -RotateVector.y, 0f);

        // Return 
        return;
    }
}
