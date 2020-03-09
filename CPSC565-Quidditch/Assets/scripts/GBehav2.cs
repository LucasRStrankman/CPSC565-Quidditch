using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/GreenBehav2")]
public class GBehav2 : GreenTeamBehaviour
{

    public void Start()
    {
        acceleration = 17f;
        maxSpeed = 15f;
        tackleChance = 0.9f;
    }

}