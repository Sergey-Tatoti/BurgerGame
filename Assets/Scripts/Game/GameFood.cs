using UnityEngine;
using UnityEngine.Events;

public class GameFood : MonoBehaviour
{
    private Food _food;

    public Food Food => _food;

    public event UnityAction<Food> TouchedGameFood;

    public void SetFood(Food food)
    {
        GetComponent<SpriteRenderer>().sprite = food.Sprite;

        _food = food;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        TouchedGameFood?.Invoke(_food);
    }
}