using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public RectTransform spawnPoint1;
    public RectTransform spawnPoint2;
    public RectTransform spawnPoint3;

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
        } else
        {
            monsterObject = Instantiate(monster,spawnPoint3);
        }

        Monster monsterReturn = monsterObject.GetComponentInChildren<Monster>();

        return monsterReturn;
    }
}
