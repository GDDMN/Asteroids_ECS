using UnityEngine;
using System;

[Serializable]
public struct ModelComponent 
{
  public Transform ModelTransform;
  public Collider2D Collider2D;
  public EntityReference EntityReference;
}