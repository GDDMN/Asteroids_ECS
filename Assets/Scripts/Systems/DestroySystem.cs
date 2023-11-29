using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class DestroySystem : IEcsRunSystem
  {
    private readonly EcsFilter<DestroyComponent, ModelComponent> _destroyFilter = null;
    private readonly EcsFilter<AsteroidsSpawnerComponent> _spawnFilter = null;
    public void Run()
    {
      ref AsteroidsSpawnerComponent spawnComponent = ref _spawnFilter.Get1(1);

      foreach(var item in _destroyFilter)
      {
        ref ModelComponent modelComponent = ref _destroyFilter.Get2(item);

        GameObject prefab = modelComponent.ModelTransform.gameObject;
        EcsEntity entity = modelComponent.EntityReference.Entity;

        if (entity.Has<AsteroidTag>())
          spawnComponent.AsteroidsCount -= 1;

        DestroyObject(entity, prefab);
      }
    }

    private void DestroyObject(EcsEntity entity, GameObject prefab)
    {
      Debug.Log("Destroy object");
      entity.Del<ModelComponent>();
      entity.Del<MovementComponent>();
      
      GameObject.Destroy(prefab);
    }
  }


}