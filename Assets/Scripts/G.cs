using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class G : MonoBehaviour
{
  private EcsWorld world;
  private EcsSystems systems;

  private void Start()
  {
    world = new EcsWorld();
    systems = new EcsSystems(world);

    systems.ConvertScene();
    systems.Init();
  }

  private void AddIjections()
  {

  }

  private void AddSystems()
  {

  }

  private void AddOneFrame()
  {

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
