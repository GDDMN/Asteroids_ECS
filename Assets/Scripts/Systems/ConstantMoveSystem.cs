using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;


namespace Asteroids.ECS.Systems
{
  public class ConstantMoveSystem : IEcsRunSystem
  {
    private readonly EcsWorld world = null;
    private readonly EcsFilter<ModelComponent, MovementComponent> constantMoveObj = null;

    public void Run()
    {
      foreach(var item in constantMoveObj)
      {
        ref ModelComponent modelComponent = ref constantMoveObj.Get1(item);
        ref MovementComponent movementComponent = ref constantMoveObj.Get2(item);

        ref Transform transform = ref modelComponent.ModelTransform;
        ref float speed = ref movementComponent.Speed;
        ref Vector2 direction = ref movementComponent.Direction;
        
        if(transform != null)
          MoveForward(transform, speed, direction);
      }
    }

    private void MoveForward(Transform transform, float speed, Vector2 direction)
    {
      Vector2 rawDirection = (direction * speed) * Time.deltaTime;
      transform.position = (Vector2)transform.position + rawDirection;
    }
  }
}

