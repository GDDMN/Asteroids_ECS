using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class PlayerDestroySystem : IEcsRunSystem
  {
    private readonly EcsFilter<DestroyComponent, PlayerTag> _destroyFilter = null;
    private readonly EcsFilter<ShipSpawnerComponent> _playerSpawnersFilter = null;
    public void Run()
    {
      foreach (var item in _destroyFilter)
      {
        ref EcsEntity entity = ref _destroyFilter.GetEntity(item);
        ModelComponent model = entity.Get<ModelComponent>();

        GameObject prefab = model.ModelTransform.gameObject;

        DestroyObject(ref entity, prefab);
        InitSpawnerWork();
      }
    }

    private void DestroyObject(ref EcsEntity entity, GameObject prefab)
    {
      entity.Destroy();
      GameObject.Destroy(prefab);
    }

    private void InitSpawnerWork()
    {
      foreach(var item in _playerSpawnersFilter)
      {
        _playerSpawnersFilter.GetEntity(item).Get<SpawnShipEvent>();
      }
    }
  }


}