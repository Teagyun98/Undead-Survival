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
		timer += Time.deltaTime; // �������� ������ ���� �ʰ� ������ �������� ���� deltaTime

		if(timer > 0.2f)
		{
			Spawn();
			timer = 0f;
		}

		void Spawn()
		{
			GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,2)); //enemy1, 2 �� �������� �����Ѵ�.
			enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;//��ġ�ص� ���� ����Ʈ�� �� �����ϰ� �����ȴ�.
		}
	}
}