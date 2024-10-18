using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private int _timeShowGameFood = 1;
    [SerializeField] private Vector3 _area;
    [SerializeField] private GameFood _gameFoodView;
    [SerializeField] private GameObject _conteinerFoods;

    private List<GameFood> _gameFoods = new List<GameFood>();
    private Coroutine _updateGameFoods;

    public event UnityAction<Food> TouchedFood;


    private void OnEnable()
    {
        if (_gameFoods != null)
        {
            for (int i = 0; i < _gameFoods.Count; i++)
            {
                _gameFoods[i].TouchedGameFood += OnTochedGameFood;
            }
        }
    }

    private void OnDisable()
    {
        if (_gameFoods != null)
        {
            for (int i = 0; i < _gameFoods.Count; i++)
            {
                _gameFoods[i].TouchedGameFood -= OnTochedGameFood;
            }
        }
    }

    public void CreateFoods(List<Food> foods)
    {
        for (int i = 0; i < foods.Count; i++)
        {
            for (int j = 0; j < foods[i].MaxCount; j++)
            {
                GameFood gameFood = Instantiate(_gameFoodView, _conteinerFoods.transform);

                gameFood.gameObject.SetActive(false);
                gameFood.SetFood(foods[i]);

                _gameFoods.Add(gameFood);
                SetRandomPosition(gameFood);

                gameFood.TouchedGameFood += OnTochedGameFood;
            }
        }
    }

    public void ActivateFoods(bool isShow)
    {
        for (int i = 0; i < _gameFoods.Count; i++)
        {
            _gameFoods[i].gameObject.SetActive(isShow);
        }

        UseUpdateGameFoods(isShow);
    }

    private IEnumerator UpdateGameFoods()
    {
        while (true)
        {
            for (int i = 0; i < _gameFoods.Count; i++)
            {
                if (_gameFoods[i].gameObject.activeSelf == false)
                {
                    SetRandomPosition(_gameFoods[i]);
                    _gameFoods[i].gameObject.SetActive(true);
                }

                yield return null;
            }

            yield return new WaitForSeconds(_timeShowGameFood);
        }
    }

    private void SetRandomPosition(GameFood gameFood)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-_area.x, _area.x) / 2, _area.y, Random.Range(-_area.z, _area.z) / 2);
        gameFood.transform.position = randomPosition;
    }

    private void UseUpdateGameFoods(bool isShow)
    {
        if (isShow == true)
            _updateGameFoods = StartCoroutine(UpdateGameFoods());
        else if (isShow == false && _updateGameFoods != null)
            StopCoroutine(_updateGameFoods);
    }

    private void OnTochedGameFood(Food food) => TouchedFood?.Invoke(food);

    private void OnDrawGizmos() => Gizmos.DrawWireCube(transform.position, _area);
}