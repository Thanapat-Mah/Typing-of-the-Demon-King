using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Script for setting how the word is displayed on canvas
public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;

    private string typedText;
    private string realText;

    //Set the text that display on the canvas
    public void SetWord ( string word )
    {
        text.text = word;
        realText = word;
    }

    public void TypedLetter (int typeIndex)
    {
        typedText = "<color=grey>";
        for(int i = 0; i < realText.Length; i++)
        {
            typedText = typedText+realText[i];
            if(i == typeIndex)
            {
                typedText = typedText+"</color>";
            }
        }
        text.text = typedText;
        typeIndex++;
    }

    public void RemovWord ()
    {
        Destroy(gameObject);
    }
}
