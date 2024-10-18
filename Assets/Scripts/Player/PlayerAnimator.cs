using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField ]private Animator _animator;

    public void SetValue() => _animator.GetComponent<Animator>();

    public void UsePreparedStartAnimation(bool isWait) => _animator.SetBool("isWait", isWait);

    public void UseMoveAnimation(bool isMove) => _animator.SetBool("isRun", isMove);
}