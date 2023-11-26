using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;


namespace Asteroids.ECS.Systems
{
  sealed class ShipMoveSystem : IEcsRunSystem
  {
    private readonly EcsWorld _wordl = null;
    private readonly EcsFilter<ShipEntity, DirectionComponent> _ships = null;

    public void Run()
    {

    }
  }

  sealed class PlayerInputSystem : IEcsRunSystem
  {
    private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

    public void Run()
    {
      Move();
      Rotate();

      foreach(var item in _directionFilter)
      {
        ref var directionComponent = ref _directionFilter.Get2(item);
      }
    }

    private void Move()
    {
            
    }

    private void Rotate()
    {

    }
  }
}


