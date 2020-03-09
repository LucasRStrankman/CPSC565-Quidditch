using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Teams/snitchTeam")]
public class SnitchTeam : QTeam
{
    public QPlayer playerPrefab;
    List<QPlayer> players = new List<QPlayer>();
    public Behaviour behaviour;
    public Vector3 spawn;

    void Start()
    {
        AddPlayer();
    }

    public override void AddPlayer()
    {
        QPlayer newPlayer = Instantiate(
        playerPrefab,
        spawn + Random.insideUnitSphere * 30,
        Random.rotation,
        transform);
        players.Add(newPlayer);
    }

    public override void RemovePlayer(QPlayer snitch)
    {
        players.Remove(snitch);
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

        }
    }
}
