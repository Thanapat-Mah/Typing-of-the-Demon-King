using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for generate the word use in the scene
public class WordGenerator : MonoBehaviour
{
	//word example
    private string[] wordList = {"ca", "py", "ba", "ra"};
	//reference to text asset .txt file
	public TextAsset file;

    private void Awake()
    {
		//reading and get word list from the file assest
		wordList = file.text.Split("\r\n");
	}

    //function for getting and return random word from the list								
    public string GetRandomWord ()
    {
		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
    }
}
