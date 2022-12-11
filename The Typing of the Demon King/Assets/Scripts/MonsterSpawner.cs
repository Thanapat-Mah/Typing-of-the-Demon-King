using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public GameObject Boss;
    public RectTransform spawnPoint1;
    public RectTransform spawnPoint2;
    public RectTransform spawnPoint3;
    public RectTransform spawnPoint4;
    public RectTransform spawnPoint5;
    public RectTransform centerPoint;

    private GameObject monsterObject;

    public Monster SpawnMonster (int monsterCount)
    {
        if(monsterCount == 0)
        {
            //Create game object from prefab with Canvas as their parent
            monsterObject = Instantiate(monster,spawnPoint1);
        } else if(monsterCount == 1)
        {
            monsterObject = Instantiate(monster,spawnPoint2);
        } else if(monsterCount == 2)
        {
            monsterObject = Instantiate(monster,spawnPoint3);
        } else if(monsterCount == 3)
        {
            monsterObject = Instantiate(monster,spawnPoint4);
        } else if(monsterCount == 4)
        {
            monsterObject = Instantiate(monster,spawnPoint5);
        } 
        else
        {
            monsterObject = Instantiate(Boss,centerPoint.position,spawnPoint2.rotation,spawnPoint2);
        }

        Monster monsterReturn = monsterObject.GetComponentInChildren<Monster>();

        return monsterReturn;
    }
}
