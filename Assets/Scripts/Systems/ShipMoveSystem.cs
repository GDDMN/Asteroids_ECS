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

    private Vector2 acceleration;

    public void Run()
    {
      foreach(var item in ships)
      {
        ref var modelComponent = ref ships.Get1(item);
        ref var shipEntity = ref ships.Get2(item);
        ref var directionComponent = ref ships.Get3(item);

        ref var direction = ref directionComponent.Direction;
        ref var rotation = ref directionComponent.Rotation;
        ref var transform = ref modelComponent.ModelTransform;

        ref var characterController = ref shipEntity.CharacterController;
        ref var rotationSpeed = ref shipEntity.RotationSpeed;
        ref var accelerationPerSeconds = ref shipEntity.AccelerationPerSeconds;
        ref var maxSpeed = ref shipEntity.MaxSpeed;
        ref var secondsToStop = ref shipEntity.SecondsToStop;

        var rawRotation = rotation * rotationSpeed;
        Vector2 rawDirection = (transform.right * direction.x) + (transform.up * direction.y);

        if (direction.y == 0)
          SlowDown(secondsToStop); 
          
        ForwardMove(rawDirection, accelerationPerSeconds, maxSpeed, characterController);        
        Rotation(transform, rawRotation);
      }
    }

    private void ForwardMove(Vector2 direction, float accelerationPerSec, float maxSpeed, CharacterController characterController)
    {
      Accelerate(direction, accelerationPerSec, maxSpeed);
      characterController.Move(acceleration);
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

    private void Rotation(Transform transform, float rotationSpeed)
    {
      transform.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    
  }
}


