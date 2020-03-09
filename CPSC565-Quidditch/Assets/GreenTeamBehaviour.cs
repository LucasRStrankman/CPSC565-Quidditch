using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/GreenTeam")]
public class GreenTeamBehaviour : TeamBehaviour
{
    [Range(1f, 100f)]
    public float acceleration = 17f;
    [Range(1f, 100f)]
    public float maxSpeed = 13f;
    public float tackleChance = 0.7f;

    public override Vector3 CalculateMove(QPlayer player)
    {
        Vector3 velocity = player.body.velocity;
        Vector3 force = player.transform.forward * acceleration;

        velocity += force;
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        return velocity;
    }

    public override bool TackleSuccess()
    {
        return (Random.Range(0, 1) > tackleChance);
    }

    public override Vector3 CalculateTurn(QPlayer player)
    {
        return GameObject.FindWithTag("Snitch").transform.position;
    }
}