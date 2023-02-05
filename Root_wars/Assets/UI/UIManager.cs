using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float timer = 3 * 60; // 3 minutes
    [SerializeField] private Text playerOneScoreText;
    [SerializeField] private Text playerTwoScoreText;

    private int playerOneScore;
    private int playerTwoScore;

    void Start()
    {
        // initialize the score variables
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void Update()
    {
        // decrement the timer by the delta time
        timer -= Time.deltaTime;

        // update the score if the timer has reached 0
        if (timer <= 0)
        {
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        // count the number of plants with the tag "child1" and "child2"
        playerOneScore = GameObject.FindGameObjectsWithTag("child1").Length;
        playerTwoScore = GameObject.FindGameObjectsWithTag("child2").Length;

        // update the text components with the new score
        playerOneScoreText.text = "Player One: " + playerOneScore;
        playerTwoScoreText.text = "Player Two: " + playerTwoScore;
    }
}
