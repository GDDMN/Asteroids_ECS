using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class ShootSystem : IEcsRunSystem
  {
    private readonly EcsWorld world = null;
    private readonly EcsFilter<WeaponComponent, ShootEvent, PlayerTag> shootFilter = null;

    private readonly float _projectileLifetime = 1f;

    public void Run()
    {
      foreach(var item in shootFilter)
      {
        ref EcsEntity entity = ref shootFilter.GetEntity(item);
        
        if (!entity.IsAlive())
          return;

        ref var weaponComponent = ref entity.Get<WeaponComponent>();
        Debug.Log(entity + ": " + weaponComponent.ShootPoint);

        SpawnProjectile(weaponComponent);
      }
    }

    private void SpawnProjectile(WeaponComponent weaponComponent)
    {
      var projectileGO = Object.Instantiate(weaponComponent.Projectile);

      var projectileEntity = world.NewEntity();

      ref var movementComponent = ref projectileEntity.Get<MovementComponent>();
      ref var modelComponent = ref projectileEntity.Get<ModelComponent>();
      ref var projectileTag = ref projectileEntity .Get<ProjectileTag>();

      movementComponent.Direction = weaponComponent.ShootPoint.transform.up;
      movementComponent.Speed = 10;

      modelComponent.ModelTransform = projectileGO.transform;
      modelComponent.ModelTransform.position = weaponComponent.ShootPoint.transform.position;
      modelComponent.Collider2D = modelComponent.ModelTransform.gameObject.GetComponent<Collider2D>();
      modelComponent.EntityReference = modelComponent.ModelTransform.gameObject.GetComponent<EntityReference>();
      modelComponent.EntityReference.Entity = projectileEntity;

      projectileTag.Lifetime = _projectileLifetime;
    }
  }


}