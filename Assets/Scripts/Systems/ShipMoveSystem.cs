using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


namespace Asteroids.ECS.Systems
{
  sealed class ShipMoveSystem : IEcsRunSystem
  {
    private readonly EcsWorld _wordl = null;
    private readonly EcsFilter<ModelComponent, ShipEntity, DirectionComponent> ships = null;

    public void Run()
    {
      foreach(var item in ships)
      {
        ref var modelComponent = ref ships.Get1(item);
        ref var shipEntity = ref ships.Get2(item);
        ref var directionComponent = ref ships.Get3(item);

        ref var direction = ref directionComponent.Direction;
        ref var transform = ref modelComponent.ModelTransform;

        ref var characterController = ref shipEntity.CharacterController;
        ref var speed = ref shipEntity.Speed;

        var rawDirection = (transform.right * direction.x) + (transform.up * direction.y);
        characterController.Move(rawDirection * speed * Time.deltaTime);
      }
    }
  }
}


