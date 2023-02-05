using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character { PlayerOne, PlayerTwo }

public class PlantingSpotController : MonoBehaviour
{
    [SerializeField] GameObject newGeometryPlayerOne; // desired geometry of the object for PlayerOne
    [SerializeField] GameObject newGeometryPlayerTwo; // desired geometry of the object for PlayerTwo
    [SerializeField] Mesh HuecoNormal;
    [SerializeField] Mesh HuecoRoots;
    private MeshFilter holeMesh;

    private SphereCollider rootCollider;

    private bool playerOneInTrigger; // flag to track if player one is in trigger
    private bool playerTwoInTrigger; // flag to track if player two is in trigger
    private bool isPlanted; // flag to track if a plant is occupying the space
    private bool rooted = false; // flag to track if the plant is rooted
    private string childType = ""; // variable to store the value of the tag of the instantiated child

    private void Start()
    {
        holeMesh = gameObject.GetComponent<MeshFilter>();
        rootCollider = gameObject.GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the other collider is player one
        if (other.CompareTag("PlayerOne"))
        {
            playerOneInTrigger = true;
        }
        // check if the other collider is player two
        else if (other.CompareTag("PlayerTwo"))
        {
            playerTwoInTrigger = true;
        }

        else if (other.CompareTag(childType))
        {
            rooted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // check if the other collider is player one
        if (other.CompareTag("PlayerOne"))
        {
            playerOneInTrigger = false;
        }
        // check if the other collider is player two
        else if (other.CompareTag("PlayerTwo"))
        {
            playerTwoInTrigger = false;
        }
    }

    void Update()
    {
        if (playerOneInTrigger && Input.GetKeyDown(KeyCode.P) && !isPlanted)
        {
            // if player one is in trigger and presses the P key, plant their plant
            PlantPlant(Character.PlayerOne);
        }

        if (playerTwoInTrigger && Input.GetKeyDown(KeyCode.Keypad0) && !isPlanted)
        {
            // if player two is in trigger and presses the Insert key, plant their plant
            PlantPlant(Character.PlayerTwo);
        }

        if (playerOneInTrigger && Input.GetKeyDown(KeyCode.C) && isPlanted)
        {
            // if player one is in trigger and presses the C key, remove the plant
            RemovePlant();
        }

        if (playerTwoInTrigger && Input.GetKeyDown(KeyCode.Period) && isPlanted)
        {
            // if player two is in trigger and presses the Period key, remove the plant
            RemovePlant();
        }

        if (isPlanted == true) 
        {
            rooted = true;
            rootCollider.radius = 3;
        }

        if (rooted == true) 
        {
            holeMesh.mesh = HuecoRoots;
        }

        if (isPlanted == false)
        {
            holeMesh.mesh = HuecoNormal;
            rootCollider.radius = 0.1f;
        }
    }

    public void PlantPlant(Character character)
    {
        GameObject newGeometry;

        // determine which new geometry to instantiate based on the character
        if (character == Character.PlayerOne)
        {
            newGeometry = newGeometryPlayerOne;
            childType = "child1";
        }
        else
        {
            newGeometry = newGeometryPlayerTwo;
            childType = "child2";
        }

        // change the geometry of the object to the desired geometry
        GameObject plantedGeometry = Instantiate(newGeometry, transform.position, transform.rotation);
        plantedGeometry.transform.parent = transform;

        // set the isPlanted flag to true
        isPlanted = true;

        rootCollider.radius = 3f;
    }

    public void RemovePlant()
    {
        // destroy the instantiated plant
        Destroy(transform.GetChild(0).gameObject);
        childType = "";
        // set the isPlanted flag to false
        isPlanted = false;
    }
}