using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QTeam : MonoBehaviour
{
    public abstract void MovePlayers();
    public abstract List<QPlayer> GetPlayers();
    public abstract void AddPlayer();
    public abstract void RemovePlayer(QPlayer p);
}