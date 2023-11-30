using UnityEngine;
using Leopotam.Ecs;

public class EcsTriggerChecker : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    EcsEntity thisEntity = GetComponent<EntityReference>().Entity;

    thisEntity.Get<DestroyComponent>();
  }
}

