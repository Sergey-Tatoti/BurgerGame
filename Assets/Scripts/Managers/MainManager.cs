using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MoveCamera _moveCamera;
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private GamePlayManager _gamePlayeManager;
    [SerializeField] private SoundManager _soundManager;

    private bool _isGame;

    private void OnEnable()
    {
        _menuManager.PreparedGame += OnPreparedGame;
        _gamePlayeManager.StartedGame += OnStartedGame;
        _gamePlayeManager.ExitedGame += OnExitedGame;
    }

    private void OnDisable()
    {
        _menuManager.PreparedGame -= OnPreparedGame;
        _gamePlayeManager.StartedGame -= OnStartedGame;
        _gamePlayeManager.ExitedGame -= OnExitedGame;
    }

    private void Start()
    {
        _soundManager.UseMusicMenu(true);
        _player.SetValue();
        _menuManager.SetValue(_player, _audioListener, _soundManager);
        _gamePlayeManager.SetValue(_player, _soundManager);
    }

    private void Update()
    {
        if(_isGame)
        {
            _moveCamera.FollowPlayer(_player);
            _player.UseAction();
        }
    }

    private void OnPreparedGame()
    {
        _soundManager.UseMusicMenu(false);
        _soundManager.UseMusicGame(true);
        _gamePlayeManager.OnPreparedGame();
    }

    private void OnStartedGame(bool isStart)
    {
        _isGame = isStart;
        _player.StartGame(isStart);
    }

    private void OnExitedGame()
    {
        _soundManager.UseMusicMenu(true);
        _soundManager.UseMusicGame(false);
        _player.StartGame(false);
        _menuManager.OnReturnedMenu();
    }
}