using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [Header("Компоненты Меню")]
    [SerializeField] private MenuUI _menuUI;
    [SerializeField] private MenuFoodsManager _menuFoodsManager;
    [SerializeField] private MenuBackGround _menuBackGround;
    [SerializeField] private Man _man;
    [SerializeField] private Cloud _cloud;
    [Header("Список еды и время появления")]
    [SerializeField] private List<FoodMenu> _foodsMenu;
    [SerializeField] private int _timeReloadFood;
    [Header("Интервал времени для приветствия от человечка")]
    [SerializeField] private int _minTimeWelcome;
    [SerializeField] private int _maxTimeWelcome;
    [Header("Продолжительнось увеличения облака до макс размера и сохранение его на определенное время")]
    [SerializeField] private int _timeHideCloud;
    [SerializeField] private float _durationScaleCloud;
    [SerializeField] private Vector2 _maxScaleCloud;
    [Header("Время загрузки и скорость заднего фона")]
    [SerializeField] private int _timeLoading;
    [SerializeField] private float _speedBackGround;

    private Player _player;
    private AudioListener _audioListener;
    private SoundManager _soundManager;

    public event UnityAction PreparedGame;

    private void OnEnable()
    {
        _menuUI.ClickedButtonPlay += OnClickedButtonPlay;
        _menuUI.ChangedEnabledMusic += OnClickedButtonMusic;
        _menuUI.ClickedButton += OnClickedButton;
        _menuFoodsManager.EatingFood += OnEatingFood;
        _man.UsedWelcome += OnUsedWelcome;
    }

    private void OnDisable()
    {
        _menuUI.ClickedButtonPlay -= OnClickedButtonPlay;
        _menuUI.ChangedEnabledMusic -= OnClickedButtonMusic;
        _menuUI.ClickedButton -= OnClickedButton;
        _menuFoodsManager.EatingFood -= OnEatingFood;
        _man.UsedWelcome -= OnUsedWelcome;
    }

    public void SetValue(Player player, AudioListener audioListener, SoundManager soundManager)
    {
        _player = player;
        _audioListener = audioListener;
        _soundManager = soundManager;

        _menuUI.SetScore(_player.GetScore());
        _menuFoodsManager.SetFoods(_foodsMenu, _timeReloadFood);
        _menuBackGround.SetValue(_speedBackGround);
        _man.SetValue(_minTimeWelcome, _maxTimeWelcome);
        _cloud.SetValue(_durationScaleCloud, _timeHideCloud, _maxScaleCloud);
    }

    public void OnReturnedMenu()
    {
        _menuBackGround.gameObject.SetActive(true);
        _menuUI.SetScore(_player.GetScore());
        _menuUI.ShowObjects(true);
    }

    private void OnClickedButtonMusic(bool isPlay) => _audioListener.enabled = isPlay;

    private void OnClickedButton() => _soundManager.UseSoundClickedButton();

    private void OnEatingFood() => _soundManager.UseSoundEatingFood();

    private void OnUsedWelcome() => _cloud.ShowWelcome();

    private void OnClickedButtonPlay()
    {
        _menuUI.ShowObjects(false);
        _menuUI.ShowLoading(true);

        Invoke(nameof(EndLoading), _timeLoading);
    }

    private void EndLoading()
    {
        _menuBackGround.gameObject.SetActive(false);
        _menuUI.ShowLoading(false);

        PreparedGame?.Invoke();
    }
}