using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_SelectionSwitch : MonoBehaviour
{
   
    // Hold the hand selection method GameObject
    public GameObject HandSelection;

    // Hold the controller selection method GameObject
    public GameObject ControllerSelection;

    // Hold the input action property for switching
    public InputActionProperty SwitchSelectionMethodInputAction;

    /*
     * @brief Activate hand selection
     * @param none
     * @return void
     */
    private void Start()
    {

        // Start with handSelection active at first
        ActivateHandSelection();
    }

    /*
     * @brief Handle activating hand selection
     * @param none
     * @return void
     */
    private void ActivateHandSelection()
    {
        
        // Check if there is a hand selection method
        if (HandSelection != null)
        {

            // Activate the hand selection method  
            HandSelection.SetActive(true);
        }
            
        // Check if there is a controller selection method
        if (ControllerSelection != null)
        {

            // Deactivate the controller selection method 
            ControllerSelection.SetActive(false);
        }
    }

    /*
     * @brief Handle activating controller selection
     * @param none
     * @return void
     */
    private void ActivateControllerSelection()
    {
        // Check if there is a hand selection method
        if (HandSelection != null)
        {

            // Deactivate the hand selection method  
            HandSelection.SetActive(false);
        }

        // Check if there is a controller selection method
        if (ControllerSelection != null)
        {

            // Activate the controller selection method 
            ControllerSelection.SetActive(true);
        }
    }

    /*
     * @brief Handle calling the correct selection method
     * @param none
     * @return void
     */
    public void SwitchSelection()
    {

        // Check if hand selection is active
        if (HandSelection.activeSelf)
        {

            // Activate the controller selection method
            ActivateControllerSelection();
        }

        // Else the controller selection method is active
        else
        {

            // Activate the hand selection method
            ActivateHandSelection();
        }
    }

    /*
     * @brief Every frame check if the input action is triggered to switch
     * selection methods
     * @param none
     * @return void
     */
    private void Update()
    {

        if (SwitchSelectionMethodInputAction.action.triggered)
            SwitchSelection();
    }
}

