using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class QPlayer : MonoBehaviour
{
    public Rigidbody body;
    public QTeam team;
    public float neighborRadius = 1.5f;
    public SphereCollider playerCollider;


    public Vector3 getVelocity() { return body.velocity; }
  
    
    void Start()
    {
        playerCollider = GetComponent<SphereCollider>();
        body = GetComponent<Rigidbody>();
    }

    public void SetTeam(QTeam nTeam)
    {
        team = nTeam;
    }

    public void Move(Vector3 velocity)
    {
        body.velocity = velocity;
    }

    public void Turn(Vector3 turnPos)
    {
        body.transform.LookAt(turnPos);
    }

    public void PlayerCrash()
    {
        body.velocity = Vector3.down * 13f;
    }

    void OnTriggerEnter(Collider enteredCollider)
    {
        if (enteredCollider.CompareTag("KillZone")){
            if (this.tag == "Red")
            {
                QPlayer r = this.GetComponent<QPlayer>();
                RedTeam rt = (RedTeam)r.team;
                rt.AddPlayer();
            } else if (this.tag == "Green")
            {
                QPlayer g = this.GetComponent<QPlayer>();
                GreenTeam gt = (GreenTeam)g.team;
                gt.AddPlayer();
            }
            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.tag == "Snitch")
        {
            GameObject g = GameObject.FindWithTag("Game");
            QGame game = g.GetComponent<QGame>();
            Destroy(GameObject.FindWithTag("Snitch"));
            game.createSnitch(this); // Passing it into here so it can be removed from the Snitch Team  
            game.UpdateScore(collision.collider.tag);   // i.e. Red, Green 
           
        }

        if (this.tag == "Red" && collision.collider.tag == "Green")
        {
            QPlayer r = this.GetComponent<QPlayer>();
            RedTeam rt = (RedTeam)r.team;
            QPlayer g = collision.collider.GetComponent<QPlayer>();
            GreenTeam gt = (GreenTeam)g.team;

            if (!rt.behaviour.TackleSuccess())
            {
                r.PlayerCrash();
               
                r.team.RemovePlayer(r);
            }
            if (!gt.behaviour.TackleSuccess())
            {
                g.PlayerCrash();
                g.team.RemovePlayer(g);
            }
        }
       
    }
}