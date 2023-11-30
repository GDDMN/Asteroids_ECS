using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  public class ShipSpawnSystem : IEcsRunSystem
  {
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ShipSpawnerComponent, SpawnShipEvent> spawnFilter = null;

    private readonly Vector2 _spawnPos = new Vector2(0f, 10f);

    public void Run()
    {
      foreach(var item in spawnFilter)
      {
        ref EcsEntity spawnEntity = ref spawnFilter.GetEntity(item);

        spawnEntity.Del<SpawnShipEvent>();

        ref ShipSpawnerComponent spawnComponent = ref spawnEntity.Get<ShipSpawnerComponent>();

        if (spawnComponent.LivesCount <= 0)
          return;

        InitShip(spawnComponent);
        spawnComponent.LivesCount--;
      }
    }

    private void InitShip(ShipSpawnerComponent spawnComponent)
    {
      GameObject shipGO = Object.Instantiate(spawnComponent.Prefab);
      shipGO.transform.position = _spawnPos;
      shipGO.transform.SetParent(spawnComponent.Pool);

      EcsEntity shipEntity = _world.NewEntity();
      SetComponents(shipEntity);

      InitPlayerMovement(ref shipEntity, shipGO);
      InitPlayerRotation(ref shipEntity);
      InitAccelerateComponent(ref shipEntity);
      InitModelComponent(ref shipEntity, shipGO);
      InitWeaponComponent(ref shipEntity, shipGO);
    }

    private void SetComponents(EcsEntity entity)
    {
      entity.Get<PlayerTag>();
      entity.Get<PlayerMovementComponent>();
      entity.Get<RotationComponent>();
      entity.Get<AccelerateComponent>();
      entity.Get<ModelComponent>();
      entity.Get<WeaponComponent>();
    }

    private void InitPlayerMovement(ref EcsEntity ship, GameObject shipGO)
    {
      ref var playerMovementComponent = ref ship.Get<PlayerMovementComponent>();
      playerMovementComponent.Rigidbody2D = shipGO.GetComponent<Rigidbody2D>();
    }

    private void InitPlayerRotation(ref EcsEntity ship)
    {
      ref var rotationComponent = ref ship.Get<RotationComponent>();
      rotationComponent.Angle = 1f;
      rotationComponent.RotationSpeed = 180f;
    }

    private void InitAccelerateComponent(ref EcsEntity ship)
    {
      ref var accelerateComponent = ref ship.Get<AccelerateComponent>();
      accelerateComponent.AccelerationPerSeconds = 5f;
      accelerateComponent.MaxSpeed = 5f;
      accelerateComponent.SecondsToStop = 0.6f;
    }

    private void InitModelComponent(ref EcsEntity ship, GameObject shipGO)
    {
      ref var modelComponent = ref ship.Get<ModelComponent>();
      modelComponent.Collider2D = shipGO.GetComponent<Collider2D>();
      modelComponent.EntityReference = shipGO.GetComponent<EntityReference>();
      modelComponent.EntityReference.Entity = ship;
      modelComponent.ModelTransform = shipGO.transform;
    }

    private void InitWeaponComponent(ref EcsEntity ship, GameObject shipGO)
    {
      ref var weaponComponent = ref ship.Get<WeaponComponent>();
      weaponComponent.ShootPoint = shipGO.transform;
      weaponComponent.Projectile = Resources.Load<GameObject>("Projectile");
    }

  }
}