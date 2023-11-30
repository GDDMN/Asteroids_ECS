using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  internal sealed class DestroySetEvent : IEcsRunSystem
  {
    private readonly EcsFilter<DestroyComponent> destroyFilter = null;

    public void Run()
    {
      foreach(var item in destroyFilter)
      {
        ref var entity = ref destroyFilter.GetEntity(item);
        entity.Get<DestroyEvent>();
      }
    }
  }


}