using UnityEngine;
using System;

[Serializable]
public struct ShipSpawnerComponent
{
  public GameObject Prefab;
  public Transform Pool;
  public int LivesCount;
  public int ShipsCount;

  public Vector2 SpawnPosition;
}


