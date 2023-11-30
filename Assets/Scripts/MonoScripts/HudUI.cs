using UnityEngine;
using TMPro;
using UniRx;

public class HudUI : MonoBehaviour
{
  private CompositeDisposable _disposable = new CompositeDisposable();

  [SerializeField] private TextMeshProUGUI _scores;
  [SerializeField] private TextMeshProUGUI _lifes;

  private void Awake()
  {
    G.Instance.Currents.Lifes.Subscribe(_ =>
    {
      UpdateLifes(G.Instance.Currents.Lifes.Value);
    }).AddTo(_disposable);

    G.Instance.Currents.Scores.Subscribe(_ =>
    {
      UpdateScores(G.Instance.Currents.Scores.Value);
    }).AddTo(_disposable);


    UpdateLifes(G.Instance.Currents.Lifes.Value);
    UpdateScores(G.Instance.Currents.Scores.Value);
  }

  private void UpdateScores(ulong count)
  {
    string scores = "Scores: ";
    _scores.text = scores + count.ToString();
  }

  private void UpdateLifes(ulong count)
  {
    string lifes = "Lifes: ";
    _lifes.text = lifes + count.ToString();
  }
}
