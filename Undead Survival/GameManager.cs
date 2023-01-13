using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager 플레이어와 poolManager의 값을 가지고 있다.

    public static GameManager instance;
    public Player player;
    public PoolManager pool;

    void Awake()
	{
        //오브젝트 활성화와 동시에 instance변수에 자기 자신을 넣는다.
        instance = this;
	}
}
