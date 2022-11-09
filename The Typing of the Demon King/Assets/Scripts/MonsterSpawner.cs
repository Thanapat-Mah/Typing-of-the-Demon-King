using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public Transform worldSpawnPoint1;
    public Transform worldSpawnPoint2;
    public Transform worldSpawnPoint3;

    private GameObject monsterObject;

    public Monster SpawnMonster (int monsterCount)
    {
        if(monsterCount == 0)
        {
            //Create game object from prefab with Canvas as their parent
            monsterObject = Instantiate(monster,worldSpawnPoint1);
        } else if(monsterCount == 1)
        {
            monsterObject = Instantiate(monster,worldSpawnPoint2);
        } else
        {
            monsterObject = Instantiate(monster,worldSpawnPoint3);
        }

        Monster monsterReturn = monsterObject.GetComponentInChildren<Monster>();

        return monsterReturn;
    }
}
