using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Transform[] spawnPoint;

	float timer;

	private void Awake()
	{
		spawnPoint = GetComponentsInChildren<Transform>();
	}

	private void Update()
	{
		timer += Time.deltaTime; // 프레임의 영향을 받지 않고 일정한 스폰량을 위한 deltaTime

		if(timer > 0.2f)
		{
			Spawn();
			timer = 0f;
		}

		void Spawn()
		{
			GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,2)); //enemy1, 2 중 랜덤으로 생성한다.
			enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;//설치해둔 스폰 포인트들 중 랜덤하게 스폰된다.
		}
	}
}
