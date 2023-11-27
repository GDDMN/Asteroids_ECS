using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class RotationSystem : IEcsRunSystem
  {
    private readonly EcsWorld world = null;
    private readonly EcsFilter<RotationComponent, ModelComponent> rotatableObjects = null;
    
    public void Run()
    {
      foreach(var item in rotatableObjects)
      {
        ref RotationComponent rotationComponent = ref rotatableObjects.Get1(item);
        ref ModelComponent modelComponent = ref rotatableObjects.Get2(item);

        
        float angle = rotationComponent.Angle;
        float rotationSpeed = rotationComponent.RotationSpeed;

        Transform transform = modelComponent.ModelTransform;

        Rotate(rotationSpeed, angle, transform);
      }
    }

    private void Rotate(float speed, float angle, Transform transform)
    {
      angle = (angle * speed) * Time.deltaTime;
      transform.Rotate(-Vector3.forward, angle);
    }
  }


}


