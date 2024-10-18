using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameCounter : MonoBehaviour
{
    private Coroutine _countDownFinishGame;
    private float _currentTime = 0;

    public event UnityAction<int> ChangedGameTime;
    public event UnityAction FinishedGame;

    public void StartCountDownFinishGame(float gameTime, bool isStart)
    {
        if (isStart)
            _countDownFinishGame = StartCoroutine(CountDownFinishGame(gameTime));
        else if (isStart && _countDownFinishGame != null)
            StopCoroutine(_countDownFinishGame);
    }

    private IEnumerator CountDownFinishGame(float gameTime)
    {
        while (gameTime > 0)
        {
            gameTime -= Time.deltaTime;

            ChangedGameTime?.Invoke((int)gameTime);

            yield return null;
        }

        FinishedGame?.Invoke();
    }
}