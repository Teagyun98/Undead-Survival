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

    //���������� FixedUpdate
	private void FixedUpdate()
	{
        //�밢�� �̵��� �� ���� ���� �������� �߰��ϴ� �ڵ�
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //��ġ�̵�
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
        //magnitude ������ ������ ũ�⸸ �ҷ���
        anim.SetFloat("Speed", inputVec.magnitude);

        //player�� �ٶ󺸴� ����
        if (inputVec.x!=0)
		{
            spriter.flipX = inputVec.x < 0;
        }
	}
}
