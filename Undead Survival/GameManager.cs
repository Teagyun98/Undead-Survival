using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager �÷��̾�� poolManager�� ���� ������ �ִ�.

    public static GameManager instance;
    public Player player;
    public PoolManager pool;

    void Awake()
	{
        //������Ʈ Ȱ��ȭ�� ���ÿ� instance������ �ڱ� �ڽ��� �ִ´�.
        instance = this;
	}
}
