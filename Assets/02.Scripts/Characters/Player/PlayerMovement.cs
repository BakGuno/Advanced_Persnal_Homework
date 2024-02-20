using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _curMoveInput;

    [Header("이동관련 스탯")]
    [SerializeField] private float speed;

    [SerializeField] private float jumpForce;

    private bool isGround;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Debug.Log(_curMoveInput);
    }

    void Move()
    {
        Vector2 dir = transform.right * _curMoveInput.x;
        dir *= speed;
        dir.y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = dir;
    }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _curMoveInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _curMoveInput = Vector2.zero; //이 부분을 바꿔주는게 좋을듯.
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        //TODO : 그라운드 감지는 레이로 하는게 좋을 듯.
        if (context.phase == InputActionPhase.Started)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}