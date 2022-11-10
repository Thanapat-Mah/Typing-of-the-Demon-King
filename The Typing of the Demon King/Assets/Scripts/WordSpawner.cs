using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    //Spawn gameobject prefab use for WordManager to get wordDisplay
    public GameObject wordPanel;
    public Transform wordCanvas;
    public RectTransform spawnPoint1;
    public RectTransform spawnPoint2;
    public RectTransform spawnPoint3;

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
        } else
        {
            wordObject = Instantiate(wordPanel,spawnPoint3);
        }
        
        //Get wordDisplay from that prefab and return it
        WordDisplay wordDisplay = wordObject.GetComponentInChildren<WordDisplay>();

        return wordDisplay;
    }
}
