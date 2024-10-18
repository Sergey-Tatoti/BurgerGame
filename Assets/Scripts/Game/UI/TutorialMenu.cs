using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonCloseTutorial;

    public event UnityAction ClosedTutorial;

    private void OnEnable() => _buttonCloseTutorial.onClick.AddListener(Close);

    private void OnDisable() => _buttonCloseTutorial.onClick.RemoveListener(Close);

    private void Close() => ClosedTutorial?.Invoke();
}