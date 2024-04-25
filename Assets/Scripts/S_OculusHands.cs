using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_OculusHands : MonoBehaviour
{

    // Hold the InputActionProperty for pinching
    public InputActionProperty PinchInputAction;

    // Hold the InputActionProperty for grabbing
    public InputActionProperty GrabInputAction;

    // Hold the animator
    public Animator HandAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Hold the trigger value
        float TriggerValue = PinchInputAction.action.ReadValue<float>();

        // Set the variable for the animator
        HandAnimator.SetFloat("Trigger", TriggerValue);

        // Hold the grab value
        float GripValue = PinchInputAction.action.ReadValue<float>();

        // Set the variable for the animator
        HandAnimator.SetFloat("Grip", GripValue);
    }
}
