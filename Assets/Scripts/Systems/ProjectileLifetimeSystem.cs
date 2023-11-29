using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  public class ProjectileLifetimeSystem : IEcsRunSystem
  {
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<ProjectileTag, ModelComponent> _projectileFilter = null;

    public void Run()
    {
      foreach(var item in _projectileFilter)
      {
        ref var entity = ref _projectileFilter.GetEntity(item);
        ref var projectileTag = ref _projectileFilter.Get1(item);
        ref var modelComponent = ref _projectileFilter.Get2(item);

        GameObject prefab = modelComponent.ModelTransform.gameObject;

        projectileTag.Lifetime -= Time.deltaTime;
        Debug.Log(projectileTag.Lifetime);

        if(projectileTag.Lifetime <= 0f)
          DestroyProjectile(entity, prefab);
      }
    }

    private void DestroyProjectile(EcsEntity entity, GameObject prefab)
    {
      Debug.Log("Destroy projectile");
      entity.Del<ProjectileTag>();
      entity.Del<ModelComponent>();
      entity.Del<MovementComponent>();
      GameObject.Destroy(prefab);
    }
  }

}