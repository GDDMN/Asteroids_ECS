using UnityEngine;
using Leopotam.Ecs;


namespace Asteroids.ECS.Systems
{
  sealed class PlayerInputSystem : IEcsRunSystem
  {
    private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

    private float _forwardMove;
    private float _rotation;

    public void Run()
    {
      SetDirection();

      foreach(var item in _directionFilter)
      {
        ref var directionComponent = ref _directionFilter.Get2(item);
        ref var direction = ref directionComponent.Direction;
        ref var rotation = ref directionComponent.Rotation;

        direction.y = _forwardMove;
        rotation = _rotation;
      }
    }

    private void SetDirection()
    {
      _rotation = Input.GetAxis("Horizontal");
      _forwardMove = Input.GetAxis("Vertical");
    }

    private void Shootig()
    {

    }
  }
}


