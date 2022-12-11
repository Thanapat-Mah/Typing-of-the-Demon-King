using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    //List of word on the scene
    public List<Word> words;
    //List of word on the scene
    public List<Monster> monsters;
    //If the word start typing hasActiveWord = true
    public bool hasActiveWord = false;
    //What word that is typing now
    private Word activeWord;
    //What monster that is typing now
    public Monster activeMonster;
    //Reference to wordSpawner C# script
    public WordSpawner wordSpawner;
    //Reference to wordGenerator of specific level
    public WordGenerator wordGenerator;
    //Reference to monster
    public MonsterSpawner monsterSpawner;
    //use to signal other that the new monster is spawn
    public bool AddNewMonster = false;
    //use to signal other that the new monster is spawn
    public bool EndOfWave = false;
    //use to switch to practice mode
    public bool practice = false;
    //Counting how many monster on screen
    private int monsterCount = 0;
    //Counting how many monster on the wave
    public int AllmonsterCount = 0;
    //Setting maximum number per wave
    public int maximumMonsterPerWave = 10;
    //Setting maximum number on scene
    private int maximumMonster = 3;

    //Start game word
    private void Start()
    {
        AddWord();
        AddWord();
    }

    private void Update()
    {
        //When there is not an activeword, set the first word in the words list to be active
        if(!hasActiveWord)
        {
            foreach(Word wordInList in words)
            {
                activeWord = wordInList;
                hasActiveWord = true;
                wordInList.SetActive();
                break;
            }
            foreach(Monster monsterInList in monsters)
            {
                activeMonster = monsterInList;
                break;
            }
        }
    }

    //Add word to the game scene
    public void AddWord()
    {
        //Random word from WordGenerator with their text display
        Word word = new Word(wordGenerator.GetRandomWord(),  wordSpawner.SpawnWord(monsterCount));
        Monster monster = monsterSpawner.SpawnMonster(monsterCount);
        words.Add(word);
        monsters.Add(monster);
        monsterCount++;
        if(monsterCount >= maximumMonster){
            monsterCount = 0;
        }
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
        }
        //When finish the whole activeword, change hasactiveword to false and remove activeword from the "words" list
        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            monsters[0].RemoveMonster();
            monsters.RemoveAt(0);
            if(practice)
            {
                AddWord();
            }
            else
            {
                AllmonsterCount++;
                Debug.Log(AllmonsterCount);
                if(AllmonsterCount < maximumMonsterPerWave-1 && !EndOfWave)
                {
                    AddWord();
                    AddNewMonster = true;
                }  
                else if(AllmonsterCount == maximumMonsterPerWave) {
                    EndOfWave = true;
                }
            }
        }
    }

    public char GetNextLetter()
    {
        if (hasActiveWord)
        {
            return activeWord.GetNextLetter();
        }
        return ' ';
    }
}
