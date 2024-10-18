using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerTouchTracker))]
[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _turnSmothTime;

    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;
    private PlayerInventory _playerInventory;
    private PlayerTouchTracker _playerTouchTracker;
    private CharacterController _characterController;

    public void SetValue()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerInventory = GetComponent<PlayerInventory>();
        _playerTouchTracker = GetComponent<PlayerTouchTracker>();
        _characterController = GetComponent<CharacterController>();

        _playerAnimator.SetValue();
    }

    public void UseAction()
    {
        _playerMovement.Move(_characterController, _speedMove, _turnSmothTime);
        _playerAnimator.UseMoveAnimation(_playerMovement.MoveDirection != Vector3.zero);
    }

    public void StartGame(bool isStart) => _playerAnimator.UsePreparedStartAnimation(!isStart);

    public void SetScore(int score) => _playerInventory.SetScore(score);

    public int GetScore() => _playerInventory.Score;
}