using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Vector2 inputVec;
    public int speed;


    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //inputVec.x = Input.GetAxisRaw("Horizontal");
        //inputVec.y = Input.GetAxis("Vertical");
    }

    //물리연산은 FixedUpdate
	private void FixedUpdate()
	{
        //대각선 이동이 더 빠른 것을 막기위해 추가하는 코드
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //위치이동
        //rigid.AddForce(inputVec);
        //rigid.velocity = inputVec;
        rigid.MovePosition(rigid.position + nextVec);
	}

	void OnMove(InputValue value)
	{
        inputVec = value.Get<Vector2>();
	}

	private void LateUpdate()
	{
        //magnitude 순수한 벡터의 크기만 불러옴
        anim.SetFloat("Speed", inputVec.magnitude);

        //player의 바라보는 방향
        if (inputVec.x!=0)
		{
            spriter.flipX = inputVec.x < 0;
        }
	}
}
