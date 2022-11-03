using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    //Spawn gameobject prefab use for WordManager to get wordDisplay
    public GameObject wordPrefab;

    public Transform wordCanvas;

    public WordDisplay SpawnWord ()
    {
        //Create game object from prefab with Canvas as their parent
        GameObject wordObject = Instantiate(wordPrefab,wordCanvas);
        //Get wordDisplay from that prefab and return it
        WordDisplay wordDisplay = wordObject.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
