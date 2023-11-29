using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class PlayerShootSetEvent : IEcsRunSystem
  {
    private readonly EcsFilter<WeaponComponent> playerFilter = null;
    public void Run()
    {
      if (!Input.GetKeyDown(KeyCode.Space)) return;

      foreach(var item in playerFilter)
      {
        ref var entity = ref playerFilter.GetEntity(item);
        entity.Get<ShootEvent>();
      }
    }
  }

}