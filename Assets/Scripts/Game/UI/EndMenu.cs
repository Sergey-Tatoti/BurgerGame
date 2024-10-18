using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _maxScore;
    [SerializeField] private TMP_Text _recordScore;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonRestart;

    public event UnityAction ExitedGame;
    public event UnityAction RestartedGame;

    private void OnEnable()
    {
        _buttonExit.onClick.AddListener(OnClickedButtonExit);
        _buttonRestart.onClick.AddListener(OnClickedButtonRestart);
    }
    private void OnDisable()
    {
        _recordScore.gameObject.SetActive(false);

        _buttonExit.onClick.RemoveListener(OnClickedButtonExit);
        _buttonRestart.onClick.RemoveListener(OnClickedButtonRestart);
    }

    public void SetScores(int score, int maxScore, bool isRecord)
    {
        _score.text = score.ToString();
        _maxScore.text = maxScore.ToString();

        if (isRecord)
            _recordScore.gameObject.SetActive(true);
    }

    private void OnClickedButtonExit()
    {
        gameObject.SetActive(false);
        ExitedGame?.Invoke();
    }

    private void OnClickedButtonRestart()
    {
        gameObject.SetActive(false);
        RestartedGame?.Invoke();
    }
}