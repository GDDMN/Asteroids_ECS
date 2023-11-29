using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Asteroids.ECS.Systems;

public class G : MonoBehaviour
{
  private EcsWorld world;
  private EcsSystems systems;

  private void Start()
  {
    world = new EcsWorld();
    systems = new EcsSystems(world);

    systems.ConvertScene();

    AddIjections();
    AddOneFrame();
    AddSystems();

    systems.Init();
  }

  private void AddIjections()
  {

  }

  private void AddSystems()
  {
    systems.Add(new PlayerInputSystem()).
            Add(new AcceleratedMoveSystem()).
            Add(new RotationSystem()).
            Add(new WrappingSystem()).
            Add(new ProjectileLifetimeSystem()).
            Add(new ConstantMoveSystem()).
            Add(new AsteroidSpawnSystem()).
            Add(new PlayerShootSetEvent()).
            Add(new ShootSystem()).
            Add(new DestroySystem());
  }

  private void AddOneFrame()
  {
    systems.OneFrame<ShootEvent>();
  }

  private void Update()
  {
    systems.Run();
  }

  private void OnDestroy()
  {
    if (systems == null) return;

    systems.Destroy(); 
    systems = null;
    world.Destroy();
    world = null;
  }
}
