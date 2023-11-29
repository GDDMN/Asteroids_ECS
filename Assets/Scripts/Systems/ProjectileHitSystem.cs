using Leopotam.Ecs;
using UnityEngine;

namespace Asteroids.ECS.Systems
{
  sealed class ProjectileHitSystem : IEcsRunSystem
  {
    private readonly EcsWorld _world=null;
    private readonly EcsFilter<ProjectileTag, ModelComponent> _profectileFilter = null;

    public void Run()
    {
      foreach(var item in _profectileFilter)
      {
        ref var modelComponent = ref _profectileFilter.Get2(item);
        ref Collider2D collider = ref modelComponent.Collider2D;
        
        //if(collider.IsTouching)
        //{
        //
        //}
      }
    }
  }

}