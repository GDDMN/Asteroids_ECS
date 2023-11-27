using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  public class WrappingSystem : IEcsRunSystem, IEcsInitSystem
  {
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ModelComponent> _wrappedObjects = null;
  
    private Camera camera;
    
  
    public void Init()
    {
      camera = Camera.main;
    }
  
    public void Run()
    {
      foreach (var item in _wrappedObjects)
      {
        ref var transform = ref _wrappedObjects.Get1(item).ModelTransform;
  
        Vector2 moveAdjustment = Vector2.zero;
        Vector2 viewportPosition = camera.WorldToViewportPoint(transform.position);
        float wrappedRelocateDistance = transform.localScale.x;

        SetAdjustment(ref moveAdjustment, ref viewportPosition, wrappedRelocateDistance);
        SetObjectPosition(transform, moveAdjustment, viewportPosition);
      }
    }
  
    private void SetAdjustment(ref Vector2 adjustment, ref Vector2 viewportPos, float weappedDistance)
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
      Vector2 position = camera.ViewportToWorldPoint(viewportPos + adjustment);
      transform.position = position;
    }
  }
}