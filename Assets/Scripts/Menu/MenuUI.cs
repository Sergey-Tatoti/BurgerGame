using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listMenuObjects;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonOnMusic;
    [SerializeField] private Button _buttonOffMusic;

    public event UnityAction ClickedButtonPlay;
    public event UnityAction ClickedButton;
    public event UnityAction<bool> ChangedEnabledMusic;

    private void OnEnable()
    {
        _buttonPlay.onClick.AddListener(ClickedButtonPlayGame);
        _buttonOnMusic.onClick.AddListener(() => ClickedButtonSound(false));
        _buttonOffMusic.onClick.AddListener(() => ClickedButtonSound(true));
    }

    private void OnDisable()
    {
        _buttonPlay.onClick.RemoveListener(ClickedButtonPlayGame);
        _buttonOnMusic.onClick.RemoveListener(() => ClickedButtonSound(false));
        _buttonOffMusic.onClick.RemoveListener(() => ClickedButtonSound(true));
    }

    public void ShowObjects(bool isShow)
    {
        for (int i = 0; i < _listMenuObjects.Count; i++)
        {
            _listMenuObjects[i].SetActive(isShow);
        }
    }

    public void SetScore(int score) => _scoreText.text = score.ToString();

    public void ShowLoading(bool isShow) => _loadingText.gameObject.SetActive(isShow);

    private void ClickedButtonSound(bool isOnMusic)
    {
        _buttonOnMusic.gameObject.SetActive(isOnMusic);
        _buttonOffMusic.gameObject.SetActive(!isOnMusic);

        ClickedButton?.Invoke();
        ChangedEnabledMusic?.Invoke(isOnMusic);
    }

    private void ClickedButtonPlayGame()
    {
        ClickedButton?.Invoke();
        ClickedButtonPlay?.Invoke();
    }
}