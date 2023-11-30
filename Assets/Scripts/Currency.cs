using System;
using UniRx;

public class Currents
{
  public ReactiveProperty<ulong> Lifes = new ReactiveProperty<ulong>();
  public ReactiveProperty<ulong> Scores = new ReactiveProperty<ulong>();
  public ReactiveProperty<ulong> HighScores =  new ReactiveProperty<ulong>();

  public ReactiveProperty<bool> GameOver = new ReactiveProperty<bool>();

  public void SetDefaultValues()
  {
    GameOver.Value = false;
    Lifes.Value = 3;
    Scores.Value = 0;
  }

  public void ResetHighScores()
  {
    HighScores.Value = 0;
  }
}




