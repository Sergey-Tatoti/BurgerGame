using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _turnSmoothVelocity;

    public Vector3 MoveDirection => _moveDirection;

    public void Move(CharacterController characterController, float speed, float turnSmothTime)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        Rotate(_moveDirection, turnSmothTime);

        characterController.Move(_moveDirection * speed * Time.deltaTime);
    }

    private void Rotate(Vector3 moveDirection, float turnSmothTime)
    {
        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}