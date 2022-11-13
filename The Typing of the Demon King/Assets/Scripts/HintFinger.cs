using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintFinger : MonoBehaviour
{
    // Text and variable for show the next letter to type
    private TextMeshProUGUI nextLetterText;
    private char nextLetter;

    // Reference to WordManager
    public WordManager wordManager;

    void Start()
    {
        nextLetterText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        // show the next letter to type
        nextLetter = wordManager.GetNextLetter();
        //Debug.Log(nextLetter);
        nextLetterText.text = "" + nextLetter;
    }

    //void UpdateFxck()
    //{
    //    // show the next letter to type
    //    nextLetter = wordManager.GetNextLetter();
    //    //nextLetterText.text = "Fxck";
    //    if (nextLetter != ' ')
    //    {
    //        nextLetterText.text = (string)nextLetter;
    //    }
    //    else
    //    {
    //        nextLetterText.text = " ";
    //    }
    //}
}
