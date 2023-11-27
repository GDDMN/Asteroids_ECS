using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class AsteroidSpawnSystem : IEcsRunSystem, IEcsInitSystem
  {

    private readonly EcsWorld world = null;
    private readonly EcsFilter<AsteroidsSpawnerComponent> spawners = null;

    private Camera camera;

    public void Init()
    {
      camera = Camera.main;
    }

    public void Run()
    {

    }
  }

}


