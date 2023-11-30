using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed public class AsteroidsDestroySystem : IEcsRunSystem
  {
    private readonly EcsFilter<DestroyComponent, AsteroidTag> _destroyFilter = null;
    private readonly EcsFilter<AsteroidsSpawnerComponent> _asteroidSpawnersFilter = null;
    public void Run()
    {
      foreach (var item in _destroyFilter)
      {
        ref EcsEntity entity = ref _destroyFilter.GetEntity(item);
        ModelComponent model = entity.Get<ModelComponent>();

        GameObject prefab = model.ModelTransform.gameObject;

        DestroyObject(ref entity, prefab);
        DecrimentAsteroidsCount();
      }
    }

    private void DestroyObject(ref EcsEntity entity, GameObject prefab)
    {
      entity.Destroy();
      GameObject.Destroy(prefab);
    }

    private void DecrimentAsteroidsCount()
    {
      foreach(var item in _asteroidSpawnersFilter)
      {
        ref var asteroidsSpawnComponent = ref _asteroidSpawnersFilter.Get1(item);
        asteroidsSpawnComponent.AsteroidsCount--;
        G.Instance.Currents.Scores.Value++;
      }
    }
  }



}