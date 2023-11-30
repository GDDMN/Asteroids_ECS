using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed public class ProjectileDestroySystem : IEcsRunSystem
  {
    private readonly EcsFilter<DestroyComponent, ProjectileTag> _destroyFilter = null;
    
    public void Run()
    {
      foreach (var item in _destroyFilter)
      {
        ref EcsEntity entity = ref _destroyFilter.GetEntity(item);
        ModelComponent model = entity.Get<ModelComponent>();

        GameObject prefab = model.ModelTransform.gameObject;

        DestroyObject(ref entity, prefab);
      }
    }

    private void DestroyObject(ref EcsEntity entity, GameObject prefab)
    {
      entity.Destroy();
      GameObject.Destroy(prefab);
    }
  }



}