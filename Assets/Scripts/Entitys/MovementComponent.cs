using UnityEngine;
using System;

[Serializable]
public struct MovementComponent
{
  public float Speed;
  [HideInInspector]public Vector2 Direction;
}

