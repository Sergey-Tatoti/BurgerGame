using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayManager : MonoBehaviour
{
    [Header("Основные компоненты")]
    [SerializeField] private GameManagerUI _gameManagerUI;
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private GameCounter _gameCounter;
    [SerializeField] private GameScore _gameScore;
    [Header("Время игры и число, после которого время меняет цвет")]
    [SerializeField] private float _gameTime = 30;
    [SerializeField] private int _dangerTime;
    [SerializeField] private Color _dangerColorTime;
    [Header("Список уникальной еды")]
    [SerializeField] private List<Food> _foods;

    private Player _player;
    private SoundManager _soundManager;

    public event UnityAction<bool> StartedGame;
    public event UnityAction ExitedGame;

    private void OnEnable()
    {
        _gameManagerUI.PreparedGame += OnPreparedGame;
        _gameManagerUI.StartedGame += OnStartedGame;
        _gameManagerUI.ExitedGame += OnExitedGame;
        _gameCounter.ChangedGameTime += OnChangedGameTime;
        _gameCounter.FinishedGame += OnFinishedGame;
        _foodSpawner.TouchedFood += OnTouchedFood;
    }

    private void OnDisable()
    {
        _gameManagerUI.PreparedGame -= OnPreparedGame;
        _gameManagerUI.StartedGame -= OnStartedGame;
        _gameManagerUI.ExitedGame -= OnExitedGame;
        _gameCounter.ChangedGameTime -= OnChangedGameTime;
        _gameCounter.FinishedGame -= OnFinishedGame;
        _foodSpawner.TouchedFood -= OnTouchedFood;
    }

    public void SetValue(Player player, SoundManager soundManager)
    {
        _player = player;
        _soundManager = soundManager;

        _gameManagerUI.SetValue((int)_gameTime, 0, _dangerTime, _dangerColorTime, _foods);
        _gameScore.SetValue(_foods);
        _foodSpawner.CreateFoods(_foods);
    }

    public void OnPreparedGame()
    {
        _gameManagerUI.ChangeScore(0);
        _gameManagerUI.ChangeCountFoods(_foods);
        _gameManagerUI.ShowTutorialMenu(true);
        _gameManagerUI.ShowGamePanels(true);
    }

    private void OnStartedGame()
    {
        StartedGame?.Invoke(true);

        _gameManagerUI.ShowTutorialMenu(false);
        _foodSpawner.ActivateFoods(true);
        _gameCounter.StartCountDownFinishGame(_gameTime, true);
    }

    private void OnExitedGame()
    {
        _gameCounter.StartCountDownFinishGame(_gameTime, false);
        _foodSpawner.ActivateFoods(false);
        _gameManagerUI.ShowGamePanels(false);
        _gameManagerUI.ShowTutorialMenu(false);
        _gameManagerUI.ShowEndMenu(false);
        _gameScore.ResetScores();

        ExitedGame?.Invoke();
    }

    private void OnFinishedGame()
    {
        _soundManager.UseSoundEndGame();
        _gameManagerUI.SetScoreEndMenu(_gameScore.Score, _player.GetScore(), _gameScore.Score > _player.GetScore());
        _gameManagerUI.ShowEndMenu(true);
        _foodSpawner.ActivateFoods(false);

        StartedGame?.Invoke(false);

        TrySetScorePlayer();
        _gameScore.ResetScores();
    }

    private void OnChangedGameTime(int time) => _gameManagerUI.ChangeTime(time);

    private void TrySetScorePlayer()
    {
        if (_gameScore.Score > _player.GetScore())
            _player.SetScore(_gameScore.Score);
    }

    private void OnTouchedFood(Food food)
    {
        _soundManager.UseSoundTakingFood();
        _gameScore.ChangeScore(food);
        _gameManagerUI.ChangeScore(_gameScore.Score);
        _gameManagerUI.ChangeCountFoods(_foods);
    }
}