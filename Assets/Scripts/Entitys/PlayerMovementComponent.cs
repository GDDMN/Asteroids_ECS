using UnityEngine;
using System;

[Serializable]
public struct PlayerMovementComponent
{
  public Rigidbody2D Rigidbody2D;
  [HideInInspector] public Vector2 Direction;
}

