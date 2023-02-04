using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private bool FirstCharacter = true;

    private KeyCode MoveUp;

    private KeyCode MoveRight;


    private void Awake()
    {
        if (FirstCharacter == true)
        {
            MoveUp = KeyCode.W;
            MoveRight = KeyCode.D;
        }

        else 
        {
            MoveUp = KeyCode.UpArrow;
            MoveRight = KeyCode.RightArrow;
        }
    }

}
