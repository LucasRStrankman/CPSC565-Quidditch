using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GreenTeam : QTeam
{
    public GreenTeamBehaviour behaviour;
    public QPlayer playerPrefab;
    List<QPlayer> players = new List<QPlayer>();
    public int numberOfPlayers = 5;
    public float neighborRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            AddPlayer();
        }
    }

    public override void AddPlayer()
    {
        QPlayer newPlayer = Instantiate(
            playerPrefab,
            transform.position,
            Random.rotation,
            transform);
        newPlayer.SetTeam(this);
        players.Add(newPlayer);
    }

    public override void RemovePlayer(QPlayer p)
    {
        players.Remove(p);
    }
    public override List<QPlayer> GetPlayers()
    {
        return players;
    }
    public override void MovePlayers()
    {
        foreach (QPlayer player in players)
        {
            Vector3 turn = behaviour.CalculateTurn(player);
            player.Turn(turn);
            Vector3 move = behaviour.CalculateMove(player);
            player.Move(move); // Move the player
            player.body.AddForce(avoidObstacles(player));
        }
    }

    Vector3 avoidObstacles(QPlayer player)
    {
        Vector3 move = Vector3.zero;
        int numAvoid = 0;
        foreach (QPlayer p in players)
        {
            Vector3 colPosition = p.transform.position;
            if (Vector3.Distance(colPosition, player.transform.position) < (player.neighborRadius)) // ATM, will avoid anything within its radius
            {
                numAvoid++;
                move += (Vector3)(player.transform.position - colPosition);
            }
        }
        if (numAvoid > 0)
        {
            move /= numAvoid;
        }
        return move * 50;
    }
}
