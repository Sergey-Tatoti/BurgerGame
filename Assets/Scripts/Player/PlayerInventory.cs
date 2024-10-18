using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool _isLose = false;
    private int _score = 0;

    public int Score => _score;
    public bool IsLose => _isLose;

    public void SetScore(int score) => _score = score;
}
