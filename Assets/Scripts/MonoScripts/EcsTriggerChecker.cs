using UnityEngine;
using Leopotam.Ecs;

public class EcsTriggerChecker : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    EcsEntity entity = collision.gameObject.GetComponent<EntityReference>().Entity;

    Destroy(collision.gameObject);
    Destroy(this.gameObject);
  }
}

