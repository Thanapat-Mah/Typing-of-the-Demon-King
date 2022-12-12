using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    //Spawn gameobject prefab use for WordManager to get wordDisplay
    public GameObject wordPanel;
    public RectTransform spawnPoint1;
    public RectTransform spawnPoint2;
    public RectTransform spawnPoint3;
    public RectTransform spawnPoint4;
    public RectTransform spawnPoint5;

    private GameObject wordObject;

    public WordDisplay SpawnWord (int monsterCount)
    {
        if(monsterCount == 0)
        {
            //Create game object from prefab with Canvas as their parent
            wordObject = Instantiate(wordPanel,spawnPoint1);
        } else if(monsterCount == 1)
        {
            wordObject = Instantiate(wordPanel,spawnPoint2);
        } else if(monsterCount == 2)
        {
            wordObject = Instantiate(wordPanel,spawnPoint3);
        } else if(monsterCount == 3)
        {
            wordObject = Instantiate(wordPanel,spawnPoint4);
        } else if(monsterCount == 4)
        {
            wordObject = Instantiate(wordPanel,spawnPoint5);
        } else if(monsterCount == 10)
        {
            wordObject = Instantiate(wordPanel,spawnPoint1.position,spawnPoint2.rotation,spawnPoint2);
        } else if(monsterCount == 11)
        {
            wordObject = Instantiate(wordPanel,spawnPoint3.position,spawnPoint2.rotation,spawnPoint2);
        } else if(monsterCount == 12)
        {
            wordObject = Instantiate(wordPanel,spawnPoint4.position,spawnPoint2.rotation,spawnPoint2);
        } else if(monsterCount == 13)
        {
            wordObject = Instantiate(wordPanel,spawnPoint5.position,spawnPoint2.rotation,spawnPoint2);
        }
        
        //Get wordDisplay from that prefab and return it
        WordDisplay wordDisplay = wordObject.GetComponentInChildren<WordDisplay>();

        return wordDisplay;
    }
}
