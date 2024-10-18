using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetFood : MonoBehaviour
{
    [SerializeField] private TMP_Text _countScore;
    [SerializeField] private Image _imageFood;

    public void Render(Sprite sprite, string countScore)
    {
        _imageFood.sprite = sprite;
        _countScore.text = countScore;
    }

    public void ChangeCountScore(string countScore) => _countScore.text = countScore;
}