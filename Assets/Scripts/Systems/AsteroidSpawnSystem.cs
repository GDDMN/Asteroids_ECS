using UnityEngine;
using Leopotam.Ecs;

namespace Asteroids.ECS.Systems
{
  sealed class AsteroidSpawnSystem : IEcsRunSystem, IEcsInitSystem
  {
    private readonly EcsWorld world = null;
    private readonly EcsFilter<AsteroidsSpawnerComponent> spawner = null;

    private Camera camera;

    private readonly float minSpeed = 1f;
    private readonly float maxSpeed = 1.4f;

    private int AsteroidsCount = 0;
    private int level = 0;
    public void Init()
    {
      camera = Camera.main;
    }

    public void Run()
    {
      if(AsteroidsCount == 0)
      {
        level++;

        int numAsteroids = 2 + (2 * level);
        for (int i = 0; i < numAsteroids; i++)
          SpawnAsteroid();
      }
    }

    private void SpawnAsteroid()
    {
      AsteroidsCount++;
      ref var asteroidSpawnComponent = ref spawner.Get1(1);

      var asteroidGO = Object.Instantiate(asteroidSpawnComponent.AsteroidPrefab);
      asteroidGO.transform.SetParent(asteroidSpawnComponent.AsteroidsPool);

      var asteroidEntity = world.NewEntity();

      ref var movementComponent = ref asteroidEntity.Get<MovementComponent>();
      ref var modelComponent = ref asteroidEntity.Get<ModelComponent>();

      movementComponent.Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
      movementComponent.Speed = Random.Range(minSpeed, maxSpeed);

      modelComponent.ModelTransform = asteroidGO.transform;
      modelComponent.ModelTransform.position = GetPosition();
      modelComponent.Collider2D = modelComponent.ModelTransform.gameObject.GetComponent<Collider2D>();
      modelComponent.EntityReference = modelComponent.ModelTransform.gameObject.GetComponent<EntityReference>();
    }

    private Vector2 GetPosition()
    {
      float offset = Random.Range(0f, 1f);
      Vector2 viewportSpawnPos = Vector2.zero;

      int edge = Random.Range(0, 4);

      if (edge == 0)
        viewportSpawnPos = new Vector2(offset, 0);
      else if(edge == 1)
        viewportSpawnPos = new Vector2(offset, 1);
      else if (edge == 2)
        viewportSpawnPos = new Vector2(0, offset);
      else if (edge == 3)
        viewportSpawnPos = new Vector2(1, offset);

      Vector2 worldPointSpawn = camera.ViewportToWorldPoint(viewportSpawnPos);
      return worldPointSpawn;
    }
  }

}


