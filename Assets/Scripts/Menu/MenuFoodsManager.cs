using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuFoodsManager : MonoBehaviour
{
    private List<FoodMenu> _foodsMenu;

    public event UnityAction EatingFood;

    private void OnDisable()
    {
        for (int i = 0; i < _foodsMenu.Count; i++)
        {
            _foodsMenu[i].ClickedFood -= OnClickedFood;
        }
    }

    public void SetFoods(List<FoodMenu> foodsMenu, int timeReloadFood)
    {
        _foodsMenu = foodsMenu;

        for (int i = 0; i < _foodsMenu.Count; i++)
        {
            _foodsMenu[i].SetValue(timeReloadFood);
            _foodsMenu[i].ClickedFood += OnClickedFood;
        }
    }

    private void OnClickedFood() => EatingFood?.Invoke();
}