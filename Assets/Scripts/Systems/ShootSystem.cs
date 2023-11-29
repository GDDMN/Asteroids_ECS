using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class ShootSystem : IEcsRunSystem
  {
    private readonly EcsWorld world = null;
    private readonly EcsFilter<WeaponComponent, ShootEvent> shootFilter = null;

    public void Run()
    {
      foreach(var item in shootFilter)
      {
        ref var weaponComponent = ref shootFilter.Get1(item);
        SpawnProjectile(weaponComponent);
      }
    }

    private void SpawnProjectile(WeaponComponent weaponComponent)
    {
      var projectileGO = Object.Instantiate(weaponComponent.Projectile);

      var projectileEntity = world.NewEntity();

      ref var movementComponent = ref projectileEntity.Get<MovementComponent>();
      ref var modelComponent = ref projectileEntity.Get<ModelComponent>();

      movementComponent.Direction = weaponComponent.ShootPoint.transform.up;
      movementComponent.Speed = 10;

      modelComponent.ModelTransform = projectileGO.transform;
      modelComponent.ModelTransform.position = weaponComponent.ShootPoint.transform.position;
    }
  }

}