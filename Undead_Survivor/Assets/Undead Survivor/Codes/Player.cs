using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec = new Vector2(0f, 0f);
    public float speed = 0f;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    void Start()
    {
            
    }

    void Update()
    {
    }
    void FixedUpdate()
    {
        Vector2 speedVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + speedVec);
        
    }
    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0f)
            spriteRenderer.flipX = inputVec.x < 0f;
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
