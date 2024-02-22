using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _curMoveInput;
    private SpriteRenderer _spriteRenderer;
    private Player _player;

    [Header("이동관련 스탯")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    private bool isGround;
    private bool jump= false;
    private bool doublejump= false;
    
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.y < 0)
        {
            if (jump)
            {
                _player.Animator.SetBool("Jump",false);
                _player.Animator.SetBool("DoubleJump",false);
                _player.Animator.SetBool("Fall",true);    
            }
        }
    }

    private void FixedUpdate()
    {
        if ((_player.Animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn") &&
            _player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)||
            (_player.Animator.GetCurrentAnimatorStateInfo(0).IsName("Die") &&
             _player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f))
        {
            return;
        }
        Move();
    }

    void Move()
    {
        Vector2 dir = transform.right * _curMoveInput.x;
        dir *= speed;
        dir.y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = dir;
        
        switch (_curMoveInput.x)
        {
            case -1:
                _spriteRenderer.flipX=true;
                break;
            case 1:
                _spriteRenderer.flipX=false;
                break;
        }
    }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _player.Animator.SetBool("Run",true);
            _curMoveInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _player.Animator.SetBool("Run",false);
            _curMoveInput = Vector2.zero; //이 부분을 바꿔주는게 좋을듯.
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        //TODO : 그라운드 감지는 레이로 하는게 좋을 듯. 여기서 땅에 닿아있는지 체크해서 jump랑 DoubleJump바꿔줘야될듯.
        if (context.phase == InputActionPhase.Started && !jump)
        {
            jump = true;
            _player.Animator.SetBool("Jump",true);
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (context.phase == InputActionPhase.Started && jump && !doublejump)
        {
            doublejump = true;
            _player.Animator.SetBool("DoubleJump",true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,0);
            _rigidbody2D.AddForce(Vector2.up * 5f, ForceMode2D.Impulse); //TODO : 손볼곳
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (groundLayer.value == (1<<other.gameObject.layer))
        {
            _player.Animator.SetBool("Fall",false);
            _player.Animator.SetBool("Jump",false); 
            _player.Animator.SetBool("DoubleJump",false); 
            jump = false;
            doublejump = false;
        }
    }
}