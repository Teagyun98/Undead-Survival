using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
	Collider2D coll;

	private void Awake()
	{
		coll = GetComponent<Collider2D>();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(!collision.CompareTag("Area"))
			return;

		Vector3 playerPos = GameManager.instance.player.transform.position;
		Vector3 myPos = transform.position;
		float diffx = Mathf.Abs(playerPos.x - myPos.x);
		float diffy = Mathf.Abs(playerPos.y - myPos.y);

		Vector3 PlayerDir = GameManager.instance.player.inputVec;
		float dirX = PlayerDir.x < 0 ? -1 : 1;
		float dirY = PlayerDir.y < 0 ? -1 : 1;

		switch(transform.tag)
		{
			case "Ground":
				if(diffx> diffy)
				{
					transform.Translate(Vector3.right * dirX * 40);
				}
				else if (diffy > diffx)
				{
					transform.Translate(Vector3.up * dirY * 40);
				}
				break;
			case "Enemy":
				if(coll.enabled)
				{
					transform.Translate(PlayerDir * 20+new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
				}
				break;
		}
	}
}
