using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character { PlayerOne, PlayerTwo }

public class PlantingSpotController : MonoBehaviour
{
    [SerializeField] GameObject newGeometryPlayerOne; // desired geometry of the object for PlayerOne
    [SerializeField] GameObject newGeometryPlayerTwo; // desired geometry of the object for PlayerTwo

    private bool playerInTrigger; // flag to track if a player is in trigger
    private bool isPlanted; // flag to track if a plant is occupying the space
    private Character characterInTrigger; // character in the trigger

    void OnTriggerEnter(Collider other)
    {
        // check if the other collider is the player
        if (other.CompareTag("PlayerOne"))
        {
            playerInTrigger = true;
            characterInTrigger = Character.PlayerOne;
        }
        else if (other.CompareTag("PlayerTwo"))
        {
            playerInTrigger = true;
            characterInTrigger = Character.PlayerTwo;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // check if the other collider is the player
        if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
        {
            playerInTrigger = false;
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.P) && !isPlanted)
        {
            GameObject newGeometry;

            // determine which new geometry to instantiate based on the character in the trigger
            if (characterInTrigger == Character.PlayerOne)
            {
                newGeometry = newGeometryPlayerOne;
            }
            else
            {
                newGeometry = newGeometryPlayerTwo;
            }

            // change the geometry of the object to the desired geometry
            GameObject plantedGeometry = Instantiate(newGeometry, transform.position, transform.rotation);
            plantedGeometry.transform.parent = transform;

            // set the isPlanted flag to true
            isPlanted = true;
        }

        if (playerInTrigger && Input.GetKeyDown(KeyCode.C) && isPlanted)
        {
            // remove the plant
            RemovePlant();
        }
    }

    public void RemovePlant()
    {
        // destroy the instantiated plant
        Destroy(transform.GetChild(0).gameObject);

        // set the isPlanted flag to false
        isPlanted = false;
    }
}