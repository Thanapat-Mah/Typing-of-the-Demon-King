using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    // Singleton Keyboard instance of the class
    public static Keyboard Instance;

    // Array of all key on the keyboard
    public static Key[] keys;
    public static List<string> selectedKeys = new List<string>();
    // Store the max lenght of generated word for praticing
    public static int maxPracticeWordLenght = 3;

    // Make sure that this is only one instance of the class
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Get all key on the keyboard
        keys = GetComponentsInChildren<Key>();

        // Set the selected keys as a previous setting, make the practice key board has memory
        foreach (string selectedKey in selectedKeys)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].GetKey() == selectedKey)
                {
                    keys[i].SetSelected(true);
                }
            }
        }
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
    }

    public static string[] GetSelectedKeys()
    {
        return selectedKeys.ToArray();
    }

    public static int GetMaxLenght()
    {
        return maxPracticeWordLenght;
    }
}
