using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class S_SpawnFurniture : XRBaseInteractable
{

    // Hold the input action to spawn the furniture
    public InputActionProperty SpawnTriggerInputAction;

    // Hold the prefab reference to the furtinure
    public GameObject FurniturePrefab;

    // Hold temp hover Material
    public Material HoverMaterial;

    // Hold the Renderer component of the spawner
    private MeshRenderer ObjectRenderer;

    // Hold the original Material list
    private List<Material> OriginalMaterials = new List<Material>();

    // Hold the reference to the spawn container prefab in the scene
    private GameObject SpawnContainer;

    // Hold a reference to script for the Spawner
    private S_Spawner SpawnerScript;

    // Hold if the spawner is being hovered
    private bool IsHovering = false;

    /*
     * @brief On script awake set the components
     * @param none
     * @return void
     */
    protected override void Awake()
    {

        // Call the base method
        base.Awake();

        // Set the MeshRenderer component from the object
        ObjectRenderer = GetComponent<MeshRenderer>();

        // Store the original materials
        OriginalMaterials.AddRange(ObjectRenderer.materials);

        // Set the spawner by finding it in the scene
        SpawnContainer = GameObject.Find("SpawnContainer");

        // Find the CubeContainer GameObject within the SpawnContainer
        GameObject CubeContainer = SpawnContainer.transform.Find("CubeContainer").gameObject;

        // Set the spawner script reference
        SpawnerScript = CubeContainer.GetComponent<S_Spawner>();

        Debug.Log(SpawnerScript);

        // Return
        return;
    }

    /*
     * @brief On hover highlight the furniture to spawn
     * @param none
     * @return void
     */
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {

        // Call the base method 
        base.OnHoverEntered(args);

        // Add the new Materials list
        ObjectRenderer.materials = new Material[] { OriginalMaterials[0], HoverMaterial };

        // Set IsHovering to true
        IsHovering = true;

        // Start the coroutine function
        StartCoroutine(DetectActivate());

        // Return
        return;
    }

    /*
     * @brief On unhover dehighlight the furniture to spawn
     * @param none
     * @return void
     */
    protected override void OnHoverExited(HoverExitEventArgs args)
    {

        // Call the base method
        base.OnHoverExited(args);

        // Remove the hover material from the list
        ObjectRenderer.materials = OriginalMaterials.ToArray();

        // Set IsHovering to false
        IsHovering = false;

        // Stop the coroutine function
        StopCoroutine(DetectActivate());

        // Return
        return;
    }

    /*
     * @brief Coroutine function that checks if the activate input is pressed
     * @param none
     * @return System.Collections.IEnumerator
     */
    private System.Collections.IEnumerator DetectActivate()
    {

        // Loop while true
        while (IsHovering)
        {

            // Check if the input is triggered
            if (SpawnTriggerInputAction.action.triggered)
            {

                // Clear spawner
                ClearSpawner();

                // Spawn furniture
                SpawnFurniture();
            }

            // Return until the next frame
            yield return null;
        }
        
        // Return until the next frame
        yield return null;
    }

    /*
     * @brief Destroy the objects in the spawner
     * @param none
     * @return void
     */
    private void ClearSpawner()
    {

        // Call the SpawnerScript's method
        SpawnerScript.ClearSpawnedObjects();

        // Return
        return;
    }

    /*
     * @brief Spawn the furniture in the spawner
     * @param none
     * @return void
     */
    private void SpawnFurniture()
    {

        // Check if there is no furniture prefab
        if (FurniturePrefab != null)
        {

            // Instantiate furniture at the center of the spawner
            GameObject Furniture = Instantiate(FurniturePrefab, SpawnContainer.transform.position, Quaternion.identity);

            // Set the furniture's position to match the spawner's position
            Furniture.transform.position = SpawnContainer.transform.position;
        }

        // Return
        return;
    }
}
