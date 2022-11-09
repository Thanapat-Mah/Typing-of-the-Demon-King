using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    // Array of all key on the keyboard
    public Key[] keys;

    void Start()
    {
        // Get all key on the keyboard
        keys = GetComponentsInChildren<Key>();
    }

    void Update()
    {
        //foreach (Key key in keys)
        //{
        //    // Get the Renderer component from the key
        //    var keyRenderer = key.GetComponent<Renderer>();

        //    //Generates a random color by generating 3 random numbers between 0.0 and 1.0.
        //    Color RandomColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        //    keyRenderer.material.color = RandomColor;
        //}
    }
}
