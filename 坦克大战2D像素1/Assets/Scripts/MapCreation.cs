using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {
    public GameObject[] item;//用来装饰地图初始化的数组
    //0老家，1土墙，2铁墙，3敌人出生效果，4河流，5草，6空气墙。
    private List<Vector3> Itemposition = new List<Vector3>();
    public float CreatEnemyTimeVal = 3;
    private void Awake()
    {   //实例化老家
        CreatMap(item[0], new Vector3(0, -8, 0));
        CreatMap(item[1], new Vector3(-1, -8, 0));
        CreatMap(item[1], new Vector3(1, -8, 0));
        for (int i = -1; i <= 1; i++)
            CreatMap(item[1], new Vector3(i, -7, 0));
        Instantiate(item[3], new Vector3(-2, -8, 0),transform.rotation);
        for (int i = 0; i < 50; i++)
        {
            CreatMap(item[1], CreatRandomPosition());
        }
        for (int i = 0; i < 10; i++)
        {
            CreatMap(item[2], CreatRandomPosition());
        }
        for (int i = 0; i < 20; i++)
        {
            CreatMap(item[4], CreatRandomPosition());
        }
        for (int i = 0; i < 20; i++)
        {
            CreatMap(item[5], CreatRandomPosition());
        }       
    }
    private void Update()
    {
        CreatEnemy();
    }
    private void CreatMap(GameObject CreatPrefab,Vector3 CreatPosition)
    {
        GameObject itemGo = Instantiate(CreatPrefab, CreatPosition, Quaternion.identity);
        itemGo.transform.SetParent(gameObject.transform);
        Itemposition.Add(CreatPosition);
    }
    //产生随机位置的方法
    private Vector3 CreatRandomPosition()
    {
        //外围不生成墙
        while(true)
        {
            Vector3 creatPosition =new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (IsWhrite(creatPosition))
            {
                return creatPosition;
            }
        }
    }
    //判断位置是否被占用
    private bool IsWhrite(Vector3 CreatPos)
    {
        for (int i = 0; i < Itemposition.Count; i++)
        {
            if (CreatPos == Itemposition[i])
                return false;
        }
        return true;
    }
    private void CreatEnemy()
    {
        GameObject Enemy;
        int num = Random.Range(0, 3);
        if (CreatEnemyTimeVal >= 3)
        {
            switch (num)
            {
                case 0:
                    Enemy = Instantiate(item[3], new Vector3(0, 8, 0), Quaternion.identity);
                    Enemy.GetComponent<Born>().CreatPlayer = false;
                    CreatEnemyTimeVal = 0;
                    break;
                case 1:
                    Enemy = Instantiate(item[3], new Vector3(-9, 8, 0), Quaternion.identity);
                    Enemy.GetComponent<Born>().CreatPlayer = false;
                    CreatEnemyTimeVal = 0;
                    break;
                case 2:
                    Enemy = Instantiate(item[3], new Vector3(9, 8, 0), Quaternion.identity);
                    Enemy.GetComponent<Born>().CreatPlayer = false;
                    CreatEnemyTimeVal = 0;
                    break;
            }

        }
        CreatEnemyTimeVal += Time.deltaTime;
    }

}
