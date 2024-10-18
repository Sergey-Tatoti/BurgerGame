using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonClose;
    [SerializeField] private Button _buttonExit;

    public event UnityAction ExitedGame;

    private void OnEnable()
    {
        _buttonExit.onClick.AddListener(ExitMenu);
        _buttonClose.onClick.AddListener(CloseMenu);
    }

    private void OnDisable()
    {
        _buttonExit.onClick.RemoveListener(ExitMenu);
        _buttonClose.onClick.RemoveListener(CloseMenu);
    }

    private void CloseMenu()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void ExitMenu()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1.0f;

        ExitedGame?.Invoke();
    }
}