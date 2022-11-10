using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    // Array of all key on the keyboard
    public Key[] keys;
    public static List<string> selectedKeys = new List<string>();
    // Store the max lenght of generated word for praticing
    public static int maxPracticeWordLenght = 3;

    void Start()
    {
        // Get all key on the keyboard
        keys = GetComponentsInChildren<Key>();
        selectedKeys.Clear();
    }

    void Update()
    {
        // Clear the List of selected key
        selectedKeys.Clear();

        // Check wheter each individual key is selected or not.
        foreach (Key key in keys)
        {
            if (key.IsSelected())
            {
                // Add the key into the List of selected key
                selectedKeys.Add(key.GetKey());
            }
        }

        //foreach (Key key in keys)
        //{
        //    // Get the Renderer component from the key
        //    var keyRenderer = key.GetComponent<Renderer>();

        //    //Generates a random color by generating 3 random numbers between 0.0 and 1.0.
        //    Color RandomColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        //    keyRenderer.material.color = RandomColor;
        //}
    }

    public void bara()
    {
        Debug.Log("capybaraaaaaaaaaaaaaa");
    }
}
