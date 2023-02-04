using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSpotController : MonoBehaviour
{
    [SerializeField] GameObject newGeometry; // desired geometry of the object

    private bool playerInTrigger; // flag to track if player is in trigger

    void OnTriggerEnter(Collider other)
    {
        // check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.P))
        {
            // change the geometry of the object to the desired geometry
            GameObject plantedGeometry = Instantiate(newGeometry, transform.position, transform.rotation);
            plantedGeometry.transform.parent = transform;

            // disable the trigger so player can't plant again
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
