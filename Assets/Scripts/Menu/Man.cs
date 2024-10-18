using UnityEngine;
using UnityEngine.Events;

public class Man : MonoBehaviour
{
    private const string UseWelcome = "UseWelcome";

    private int _minTimeWelcome;
    private int _maxTimeWelcome;

    private Animator _animator;

    public event UnityAction UsedWelcome;

    private void OnEnable()
    {
        if (_animator != null)
            StartUseWelcome();
    }

    public void SetValue(int minTimeValue, int maxTimeValue)
    {
        _animator = GetComponent<Animator>();

        _minTimeWelcome = minTimeValue;
        _maxTimeWelcome = maxTimeValue;

        StartUseWelcome();
    }

    public void StartUseWelcome()
    {
        int randomTime = Random.Range(_minTimeWelcome, _maxTimeWelcome);

        Invoke(nameof(ShowWelcome), randomTime);
    }

    private void ShowWelcome()
    {
        _animator.SetTrigger(UseWelcome);

        UsedWelcome?.Invoke();

        StartUseWelcome();
    }
}