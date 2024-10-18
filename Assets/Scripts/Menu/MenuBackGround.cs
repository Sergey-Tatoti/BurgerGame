using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackGround : MonoBehaviour
{
    private RawImage _rawImage;
    private float _speed;

    private void OnEnable()
    {
        if (_rawImage != null)
            StartCoroutine(UseMove());
    }

    public void SetValue(float speed)
    {
        _rawImage = GetComponent<RawImage>();
        _speed = speed;

        StartCoroutine(UseMove());
    }

    private IEnumerator UseMove()
    {
        float imagePositionY = 0;

        while(true)
        {
            imagePositionY += Time.deltaTime * _speed;

            _rawImage.uvRect = new Rect(0, imagePositionY, _rawImage.uvRect.width, _rawImage.uvRect.height);

            yield return null;
        }
    }
}