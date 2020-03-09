using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QGame : MonoBehaviour
{
    public GameObject[] walls;
    public SnitchTeam snitchTeam;
    public QTeam redTeam;
    public QTeam greenTeam;


    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    int MAX_SCORE = 10;
    int redScore;
    int greenScore;


    // Start is called before the first frame update
    void Start()
    {
        redScore = 0;
        greenScore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        greenTeam.MovePlayers();
        redTeam.MovePlayers();
  
        snitchTeam.MovePlayers();
    }
    public void UpdateScore(string team)
    {
        if (team == "Red"){redScore++;} 
        else if (team == "Green") { greenScore++; } 
        else { Debug.Log("A Scoring Mistake Occured"); }
        Debug.Log("The Score is now R|G: " + redScore + "|" + greenScore);
    }

    public void createSnitch(QPlayer oldSnitch)
    {
        snitchTeam.RemovePlayer(oldSnitch);
        snitchTeam.AddPlayer();
    }
}