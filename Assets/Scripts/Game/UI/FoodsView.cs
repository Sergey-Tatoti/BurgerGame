using System.Collections.Generic;
using UnityEngine;

public class FoodsView : MonoBehaviour
{
    private const string SymbolMyltiply = "*";

    [SerializeField] private TargetFood _targetFood;
    [SerializeField] private GameObject _panelTarget;

    private List<TargetFood> _targetsFood = new List<TargetFood>();

    public void CreateTargetFoods(List<Food> foods)
    {
        for (int i = 0; i < foods.Count; i++)
        {
            TargetFood targetFood = Instantiate(_targetFood, _panelTarget.transform);

            targetFood.Render(foods[i].Sprite, foods[i].CountScore + SymbolMyltiply + foods[i].Modifier);
            _targetsFood.Add(targetFood);
        }
    }

    public void ChangeCountFoods(List<Food> foods)
    {
        for (int i = 0; i < _targetsFood.Count; i++)
        {
            _targetsFood[i].ChangeCountScore(foods[i].CountScore + SymbolMyltiply + foods[i].Modifier);
        }
    }
}