using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private Vector3 _offset;

    public void FollowPlayer(Player player)
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + _offset, _followSpeed);
    }
}