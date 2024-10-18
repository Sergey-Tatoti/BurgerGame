using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private List<Food> _foods;
    private int _score = 0;

    public int Score => _score;

    private void OnDisable() => ResetScores();

    public void SetValue(List<Food> foods)
    {
        _foods = foods;
    }

    public void ResetScores()
    {
        _score = 0;

        for (int i = 0; i < _foods.Count; i++)
        {
            _foods[i].ResetScore();
        }
    }

    public void ChangeScore(Food food)
    {
        _score += (int)food.Modifier;

        for (int i = 0; i < _foods.Count; i++)
        {
            if (_foods[i].Modifier == food.Modifier)
                _foods[i].ChangeCountScore();
        }
    }


}