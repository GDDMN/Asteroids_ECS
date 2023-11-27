using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  public class AsteroidsMoveSystem : IEcsRunSystem
  {
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MovementComponent>.Exclude<PlayerTag> _asteroids = null;
    public void Run()
    {
      foreach(var item in _asteroids)
      {
        ref var movementComponent = ref _asteroids.Get1(item);
        ref float speed = ref movementComponent.Speed;


      }
    }
  
    
  }
}