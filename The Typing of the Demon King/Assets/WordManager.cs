using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    //List of word on the scene
    public List<Word> words;
    //If the word start typing hasActiveWord = true
    private bool hasActiveWord;
    //What word that is typing now
    private Word activeWord;
    //Reference to wordSpawner C# script
    public WordSpawner wordSpawner;

    //Start game word
    private void Start()
    {
        AddWord();
    }

    //Add word to the game scene
    public void AddWord()
    {
        //Random word from WordGenerator with their text display
        Word word = new Word(WordGenerator.GetRandomWord(),  wordSpawner.SpawnWord());
        Debug.Log(word.word);

        words.Add(word);
    }

    //When typing function
    public void TypeLetter (char letter)
    {
        //For typing activeword
        if(hasActiveWord)
        {
            //If the typing letter match the activeword, type the letter to the word 
            // (Remove the letter and move to the next letter in the word)
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        } else
        {
            //When there is not an activeword, search from all the word in the scene the word that match the letter
            foreach(Word word in words)
            {
                if(word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        //When finish the whole activeword, change hasactiveword to false and remove activeword from the "words" list
        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
