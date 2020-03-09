using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/snitchBehaviour")]
public class SnitchBehaviour : Behaviour
{
    [Range(1f, 100f)]
    public float acceleration = 20f;
    [Range(1f, 100f)]
    public float maxSpeed = 18f;
    Vector3 targetLocation;


    public override Vector3 CalculateMove(QPlayer snitch)
    {
        Vector3 velocity = snitch.body.velocity;
        Vector3 force = snitch.transform.forward * acceleration;

        velocity += force;
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        return velocity;

    }

    public override Vector3 CalculateTurn(QPlayer snitch)
    {
       
        if (targetLocation == Vector3.zero || (snitch.transform.position - targetLocation).magnitude < 10)
        {
           // Debug.Log("TargetLocation " + targetLocation);
            targetLocation = new Vector3(Random.Range(-75f, 75), Random.Range(5f, 100f), Random.Range(-75f, 75f));
           
        }
        return targetLocation;
    }
}
