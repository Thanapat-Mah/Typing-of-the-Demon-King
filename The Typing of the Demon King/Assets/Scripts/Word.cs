using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Class for word
public class Word
{
    public string word;
    private int typeIndex;

    WordDisplay display;

    public Word (string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);
    }

    //Get the word letter from index
    public char GetNextLetter ()
    {
        return word[typeIndex];
    }

    //Move the index to the next letter when typing
    public void TypeLetter ()
    {
        display.TypedLetter(typeIndex);
        typeIndex++;
        //Remove the letter on screen
    }

    public void SetActive ()
    {
        display.SetActive();
    }

    //Check if the word was typed to the last letter, if it is then return true
    public bool WordTyped ()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if(wordTyped)
        {
            //Remove the word on screen
            display.RemoveWord();
        }
        return wordTyped;
    }
}
