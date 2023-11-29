using System;
using UnityEngine;

[Serializable]
public struct AsteroidsSpawnerComponent
{
  public Transform AsteroidsPool;
  public GameObject AsteroidPrefab;

  public int AsteroidsCount;
}
