using UnityEngine;

[CreateAssetMenu(fileName = "Create Food", menuName = "Food", order = 51)]

public class Food : ScriptableObject
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _countScore;
    [SerializeField] private float _modifier;
    [SerializeField] private Sprite _sprite;

    public int MaxCount => _maxCount;
    public int CountScore => _countScore;
    public float Modifier => _modifier;
    public Sprite Sprite => _sprite;

    public void ChangeCountScore() => _countScore += 1;

    public void ResetScore() => _countScore = 0;
}