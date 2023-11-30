using UnityEngine;
using UnityEngine.UI;
using UniRx;

using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
  private CompositeDisposable _disposable = new CompositeDisposable();

  [SerializeField] private GameObject _conteiner;
  [SerializeField] private Button _restartButton;

  private void Awake()
  {
    G.Instance.Currents.GameOver.Subscribe(_ => {

      SetConteinerActive(G.Instance.Currents.GameOver.Value);

    }).AddTo(_disposable);

    SetConteinerActive(G.Instance.Currents.GameOver.Value);
    _restartButton.onClick.AddListener(ResetGame); 
  }

  private void SetConteinerActive(bool isActive)
  {
    _conteiner.SetActive(isActive);
  }

  private void ResetGame()
  {
    G.Instance.RestartGame();
  }
}
