using UnityEngine;
using Leopotam.Ecs;


namespace Asteroids.ECS.Systems
{
  sealed class PlayerInputSystem : IEcsRunSystem
  {
    private readonly EcsFilter<PlayerTag, RotationComponent, PlayerMovementComponent> _playerFilter = null;

    private float _forwardMove;
    private float _angle;

    public void Run()
    {
      SetDirection();

      foreach(var item in _playerFilter)
      {
        ref RotationComponent rotationComponent = ref _playerFilter.Get2(item);
        ref PlayerMovementComponent movementComponent = ref _playerFilter.Get3(item);

        ref var direction = ref movementComponent.Direction;
        ref var angle = ref rotationComponent.Angle;

        direction.y = _forwardMove;
        angle = _angle;
      }
    }

    private void SetDirection()
    {
      _angle = Input.GetAxis("Horizontal");
      _forwardMove = Input.GetAxis("Vertical");
    }
  }
}


