using UnityEngine;
using System;

[Serializable]
public struct PlayerMovementComponent
{
  public CharacterController CharacterController;
  [HideInInspector] public Vector2 Direction;
}

