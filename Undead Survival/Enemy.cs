using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target; //플레이어

	bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

	private void Awake()
	{
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		if (!isLive)
			return;

		Vector2 dirvec = target.position - rigid.position; //움직일 방향
		Vector2 nextVec = dirvec.normalized * speed * Time.fixedDeltaTime;//프레임과 상관없이 일정한 움직임
		rigid.MovePosition(rigid.position + nextVec);
		rigid.velocity = Vector2.zero;
	}

	private void LateUpdate()
	{
		if (!isLive)
			return;

		spriter.flipX = target.position.x < rigid.position.x;
	}

	private void OnEnable()
	{
		target = GameManager.instance.player.GetComponent<Rigidbody2D>();
	}
}
