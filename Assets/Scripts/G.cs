using UnityEngine;
using UnityEngine.SceneManagement;

public class G : Singleton<G>
{
  public Currents Currents = new Currents();
  public GameObject EcsStartUp;

  private void Awake()
  {
    Currents.SetDefaultValues();
    var ecsStartup = Instantiate(EcsStartUp);
  }

  public void RestartGame()
  {
    SceneManager.LoadScene("SampleScene");
    Currents.SetDefaultValues();
  }
}




