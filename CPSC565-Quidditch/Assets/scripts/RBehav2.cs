using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/RedBehave2")]
public class RBbhav2 : RedTeamBehaviour
{
  

    public void Start()
    {
        acceleration = 20f;
        maxSpeed = 16f;
        tackleChance = 0.1f;
    }
}