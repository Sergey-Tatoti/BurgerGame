using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    [Header("UI елементы")]
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Button _buttonPause;
    [Header("Основные компоненты")]
    [SerializeField] private FoodsView _foodsView;
    [SerializeField] private TutorialMenu _tutorialMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private EndMenu _endMenu;
    [SerializeField] private GamePanels _gamePanels;

    private int _dangerTime;
    private Color _baseColorTime;
    private Color _dangerColorTime;

    public event UnityAction PreparedGame;
    public event UnityAction StartedGame;
    public event UnityAction ExitedGame;

    private void OnEnable()
    {
        _buttonPause.onClick.AddListener(OpenButtonPause);
        _pauseMenu.ExitedGame += OnExitedGame;
        _endMenu.ExitedGame += OnExitedGame;
        _endMenu.RestartedGame += OnRestartedGame;
        _tutorialMenu.ClosedTutorial += OnClosedTutorial;
    }

    private void OnDisable()
    {
        _buttonPause.onClick.RemoveListener(OpenButtonPause);
        _pauseMenu.ExitedGame -= OnExitedGame;
        _endMenu.ExitedGame -= OnExitedGame;
        _endMenu.RestartedGame -= OnRestartedGame;
        _tutorialMenu.ClosedTutorial -= OnClosedTutorial;
    }

    public void SetValue(int time, int score, int dangerTime, Color dangerColorTime, List<Food> foods)
    {
        _time.text = time.ToString();
        _score.text = score.ToString();
        _dangerTime = dangerTime;
        _baseColorTime = _time.color;
        _dangerColorTime = dangerColorTime;
        _foodsView.CreateTargetFoods(foods);
    }

    public void SetScoreEndMenu(int score, int maxScore, bool isRecord) => _endMenu.SetScores(score, maxScore, isRecord);

    public void ShowEndMenu(bool isShow) => _endMenu.gameObject.SetActive(isShow);

    public void ShowGamePanels(bool isShow) => _gamePanels.gameObject.SetActive(isShow);

    public void ShowTutorialMenu(bool isShow) => _tutorialMenu.gameObject.SetActive(isShow);

    public void ChangeScore(int score) => _score.text = score.ToString();

    public void ChangeCountFoods(List<Food> foods) => _foodsView.ChangeCountFoods(foods);

    public void ChangeTime(int time)
    {
        _time.text = time.ToString();

        ChangeColor(time);
    }

    private void OnRestartedGame() => PreparedGame?.Invoke();

    private void OnClosedTutorial() => StartedGame?.Invoke();

    private void OnExitedGame() => ExitedGame?.Invoke();

    private void OpenButtonPause()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void ChangeColor(int time)
    {
        if (time > _dangerTime)
            _time.color = _baseColorTime;
        else
            _time.color = _dangerColorTime;
    }
}