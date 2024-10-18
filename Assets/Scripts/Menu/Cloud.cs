using UnityEngine;
using DG.Tweening;

public class Cloud : MonoBehaviour
{
    private float _durationScale;
    private int _timeHide;
    private Vector3 _maxScale;

    public void SetValue(float durationScale, int timeHide, Vector2 maxScale)
    {
        _durationScale = durationScale;
        _timeHide = timeHide;
        _maxScale = maxScale;
    }

    public void ShowWelcome()
    {
        transform.DOScale(_maxScale, _durationScale).Complete();
        {
            Invoke(nameof(HideCloud), _timeHide);
        };
    }

    private void HideCloud() => transform.DOScale(Vector2.zero, _durationScale);
}