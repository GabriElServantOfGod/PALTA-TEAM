using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSpotController : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.P))
        {
            SomeCoolAction();
        }
    }

    public void SomeCoolAction()
    {
        print("Occupied");
    }

}
