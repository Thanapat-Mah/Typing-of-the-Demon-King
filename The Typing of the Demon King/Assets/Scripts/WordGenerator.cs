using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for generate the word use in the scene
public class WordGenerator : MonoBehaviour
{
	//word example
    private string[] wordList = {"ca", "py", "ba", "ra"};
	/// Edit this part for using with the practice mode //////////////////////////
	//reference to text asset .txt file
	public TextAsset file = null;
	//reference to the maximum lenght of word generated in practicing mode
	private int maxPracticeWordLenght;

    private void Awake()
    {
		//if there is a file path, reading and get word list from the file assest
		if(file != null)
		{
			wordList = file.text.Split("\r\n");
		}
		else
        {
			wordList = Keyboard.GetSelectedKeys();
			maxPracticeWordLenght = Keyboard.GetMaxLenght();
		}
	}

    //function for getting and return random word from the list								
    public string GetRandomWord ()
    {
		int randomIndex;
		string randomWord;

		if (file != null)
		{
			randomIndex = Random.Range(0, wordList.Length);
			randomWord = wordList[randomIndex];
		}
        else
        {
			randomIndex = Random.Range(0, wordList.Length);
			randomWord = wordList[randomIndex];
			int randomLenght = Random.Range(1, maxPracticeWordLenght+1);
			for (int i = 1; i < randomLenght; i++)
            {
				randomIndex = Random.Range(0, wordList.Length);
				randomWord += wordList[randomIndex];
			}
        }

		return randomWord;
    }
}
