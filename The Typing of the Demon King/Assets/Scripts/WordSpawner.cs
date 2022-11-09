using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    //Spawn gameobject prefab use for WordManager to get wordDisplay
    public GameObject wordPanel;
    public Camera MainCamera;
    public Transform wordCanvas;
    public Transform worldSpawnPoint1;
    public Transform worldSpawnPoint2;
    public Transform worldSpawnPoint3;
    public RectTransform spawnPoint1;
    public RectTransform spawnPoint2;
    public RectTransform spawnPoint3;

    private GameObject wordObject;

    public WordDisplay SpawnWord (int monsterCount)
    {
        Vector3 screenPos1 = MainCamera.WorldToScreenPoint(worldSpawnPoint1.position);
        Vector3 screenPos2 = MainCamera.WorldToScreenPoint(worldSpawnPoint2.position);
        Vector3 screenPos3 = MainCamera.WorldToScreenPoint(worldSpawnPoint3.position);
        Vector3 uiPos1 = new Vector3(screenPos1.x-960, screenPos1.y-540, screenPos1.z);
        Vector3 uiPos2 = new Vector3(screenPos2.x-960, screenPos2.y-540, screenPos2.z);
        Vector3 uiPos3 = new Vector3(screenPos3.x-960, screenPos3.y-540, screenPos3.z);
        spawnPoint1.anchoredPosition = uiPos1;
        spawnPoint2.anchoredPosition = uiPos2;
        spawnPoint3.anchoredPosition = uiPos3;

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
