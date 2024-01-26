using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpforce = 8.0f;
    public float speed = 1.0f;
    private float movedierctioon;
    private bool moving;
    private bool jump;
    private bool grounded = true;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _Anim;
    private SpriteRenderer _spriterenderer;

    void Awake()
    {
        _Anim = GetComponent<Animator>();
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();        
        _spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()  
    {
        if(_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        _rigidbody2D.velocity = new Vector2((speed * movedierctioon),_rigidbody2D.velocity.y);

        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,jumpforce);
            jump = false;
        }
    }

    private void Update()
    {
        if(grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _Anim.SetFloat("speed",speed);
            if (Input.GetKey(KeyCode.A))
            {
                movedierctioon = -1.0f;
                _spriterenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movedierctioon = 1.0f;
                _spriterenderer.flipX = false;
            }
        }
        else if(grounded == true)
        {
            _Anim.SetFloat("speed",0.0f);
            movedierctioon = 0.0f;
        }

        if (grounded ==true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _Anim.SetTrigger("jump");
            _Anim.SetBool("grounded",false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Zemin")
        {
            grounded = true;
            _Anim.SetBool("grounded",true);     
        }
    }
}




















