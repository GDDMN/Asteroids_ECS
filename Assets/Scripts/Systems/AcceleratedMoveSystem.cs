using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class AcceleratedMoveSystem : IEcsRunSystem
  {
    private readonly EcsWorld _wordl = null;
    private readonly EcsFilter<ModelComponent, PlayerMovementComponent, AccelerateComponent> ships = null;

    private Vector2 acceleration;

    public void Run()
    {
      foreach (var item in ships)
      {
        ref ModelComponent modelComponent = ref ships.Get1(item);
        ref PlayerMovementComponent movementComponent = ref ships.Get2(item);
        ref AccelerateComponent accelerateComponent = ref ships.Get3(item);

        if (modelComponent.ModelTransform == null) 
          return;
        
        ref Transform transform = ref modelComponent.ModelTransform;

        ref Vector2 direction = ref movementComponent.Direction;
        ref Rigidbody2D rigidbody = ref movementComponent.Rigidbody2D;

        ref float accelerationPerSeconds = ref accelerateComponent.AccelerationPerSeconds;
        ref float maxSpeed = ref accelerateComponent.MaxSpeed;
        ref float secondsToStop = ref accelerateComponent.SecondsToStop;

        Vector2 rawDirection = (transform.right * direction.x) + (transform.up * direction.y);

        if (direction.y == 0)
          SlowDown(secondsToStop);

        ForwardMove(rawDirection, accelerationPerSeconds, maxSpeed, ref rigidbody);
      }
    }

    private void ForwardMove(Vector2 direction, float accelerationPerSec, float maxSpeed, ref Rigidbody2D rigidbody)
    {
      Accelerate(direction, accelerationPerSec, maxSpeed);
      rigidbody.velocity = acceleration;
    }

    private void Accelerate(Vector2 direction, float accelerationPerSeconds, float maxSpeed)
    {
      acceleration += direction * (accelerationPerSeconds * Time.deltaTime);
      acceleration = Vector2.ClampMagnitude(acceleration, maxSpeed);
    }

    private void SlowDown(float secondsToStop)
    {
      acceleration += -acceleration * (Time.deltaTime / secondsToStop);
    }

  }
}


