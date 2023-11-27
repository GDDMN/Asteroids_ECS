using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class WrappingSystem : IEcsRunSystem
{
  private readonly EcsWorld _world = null;
  private readonly EcsFilter<ModelComponent, PlayerTag> wrappedObjects = null;

  public void Run()
  {
    foreach(var item in wrappedObjects)
    {
      ref var transform = ref wrappedObjects.Get1(item).ModelTransform;

      Vector2 moveAdjustment = Vector2.zero;
      Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

      SetAdjustment(ref moveAdjustment, ref viewportPosition);
      SetObjectPosition(transform, moveAdjustment, viewportPosition);
    }
  }

  private void SetAdjustment(ref Vector2 adjustment, ref Vector2 viewportPos)
  {
    if (viewportPos.x < 0)
      adjustment.x += 1;
    else if (viewportPos.x > 1)
      adjustment.x -= 1;
    else if (viewportPos.y < 0)
      adjustment.y += 1;
    else if (viewportPos.y > 1)
      adjustment.y -= 1;
  }

  private void SetObjectPosition(Transform transform, Vector2 adjustment, Vector2 viewportPos)
  {
    Vector2 position = Camera.main.ViewportToWorldPoint(viewportPos + adjustment);
    transform.position = position;
  }
}
