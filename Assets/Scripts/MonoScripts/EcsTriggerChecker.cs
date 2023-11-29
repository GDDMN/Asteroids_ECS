using UnityEngine;
using Leopotam.Ecs;

public class EcsTriggerChecker : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    EcsEntity collidedEntity = collision.gameObject.GetComponent<EntityReference>().Entity;
    EcsEntity thisEntity = GetComponent<EntityReference>().Entity;

    collidedEntity.Get<DestroyComponent>();
    thisEntity.Get<DestroyComponent>();
  }
}

