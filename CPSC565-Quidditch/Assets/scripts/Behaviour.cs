using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behaviour : ScriptableObject
{
    public abstract Vector3 CalculateMove(QPlayer agent);
    public abstract Vector3 CalculateTurn(QPlayer agent);
}
