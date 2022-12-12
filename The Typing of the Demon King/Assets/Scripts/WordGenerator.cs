using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for generate the word use in the scene
public class WordGenerator : MonoBehaviour
{
	//word example
    private string[] wordList = { "ca", "py", "ba", "ra" };
	//word example
    private string[] BosswordList = { "ca", "py", "ba", "ra" };
	/// Edit this part for using with the practice mode //////////////////////////
	//reference to text asset .txt file
	public TextAsset file = null;
	public TextAsset Bossfile = null;
	//reference to the maximum lenght of word generated in practicing mode
	private int maxPracticeWordLenght;

    private void Awake()
    {
		if(Bossfile != null)
		{
			BosswordList = Bossfile.text.Split("\r\n");
		}
		//if there is a file path, reading and get word list from the file assest
		if(file != null)
		{
			wordList = file.text.Split("\r\n");
		}
		else
        {
			wordList = Keyboard.GetSelectedKeys();
            // hotfix using a default character when there is no selected key.
            if(wordList.Length == 0)
            {
				wordList = new string[1] { "a" };
            }
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

	//function for getting and return random word from the list								
    public string GetBossRandomWord ()
    {
		int randomIndex;
		string randomWord;

		if (Bossfile != null)
		{
			randomIndex = Random.Range(0, BosswordList.Length);
			randomWord = BosswordList[randomIndex];
		}
        else
        {
			randomIndex = Random.Range(0, BosswordList.Length);
			randomWord = BosswordList[randomIndex];
			int randomLenght = Random.Range(1, maxPracticeWordLenght+1);
			for (int i = 1; i < randomLenght; i++)
            {
				randomIndex = Random.Range(0, BosswordList.Length);
				randomWord += BosswordList[randomIndex];
			}
        }

		return randomWord;
    }
}
