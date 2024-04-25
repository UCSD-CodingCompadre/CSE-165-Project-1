using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{

    // Hold the list of objects spawned in the SpawnerContainer
    private List<GameObject> SpawnedObjects = new List<GameObject>();

    /*
     * @brief On trigger enter add the gameobject that entered
     * @param Collider Other the collider that triggered the SpawnContainer
     * @return void
     */
    private void OnTriggerEnter(Collider Other)
    {

        // Add the object to the list when it enters the trigger
        SpawnedObjects.Add(Other.gameObject);

        // Return
        return;
    }

    /*
     * @brief On trigger enter remove the gameobject that entered
     * @param Collider Other the collider that triggered the SpawnContainer
     * @return void
     */
    private void OnTriggerExit(Collider Other)
    {

        // Remove the object from the list when it exits the trigger
        SpawnedObjects.Remove(Other.gameObject);

        // Return
        return;
    }

    /*
     * @brief Clear the objects that are still in the SpawnContainer
     * @param none
     * @return void
     */
    public void ClearSpawnedObjects()
    {

        // Destroy all objects in the list
        foreach (GameObject SpawnedObject in SpawnedObjects)
        {

            // Destroy the object
            Destroy(SpawnedObject);
        }

        // Clear the list
        SpawnedObjects.Clear();

        // Return
        return;
    }
}
