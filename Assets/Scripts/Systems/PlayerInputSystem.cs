using UnityEngine;
using Leopotam.Ecs;


namespace Asteroids.ECS.Systems
{
  sealed class PlayerInputSystem : IEcsRunSystem
  {
    private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

    private float forwardMove;
    private float rotation;

    public void Run()
    {
      SetDirection();

      foreach(var item in _directionFilter)
      {
        ref var directionComponent = ref _directionFilter.Get2(item);
        ref var direction = ref directionComponent.Direction;

        direction.x = rotation;
        direction.y = forwardMove;
      }
    }

    private void SetDirection()
    {
      rotation = Input.GetAxis("Horizontal");
      forwardMove = Input.GetAxis("Vertical");
    }
  }
}


