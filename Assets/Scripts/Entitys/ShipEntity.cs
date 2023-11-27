using UnityEngine;
using System;

[Serializable]
public struct ShipEntity
{
  public CharacterController CharacterController;

  [Header("Movements Data")]
  //public Vector2 Acceleration;
  public float AccelerationPerSeconds;
  public float SecondsToStop;
  public float MaxSpeed;

  [Header("Rotation Data")]
  public float RotationSpeed;
}
