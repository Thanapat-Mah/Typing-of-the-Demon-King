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
    //use to signal other that This is in the Boss Phase
    public bool BossMode = false;
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
        // StatManager.Instance.StartCalculateStatistic();
        TimeManager.Instance.StartTimer();
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
        // Debug.Log(TimeManager.Instance.GetTime());
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

    public void AddBossWord()
    {
        //Random word from WordGenerator with their text display
        Word word = new Word(wordGenerator.GetBossRandomWord(),  wordSpawner.SpawnWord(10));
        words.Add(word);
        word = new Word(wordGenerator.GetBossRandomWord(),  wordSpawner.SpawnWord(11));
        words.Add(word);
        word = new Word(wordGenerator.GetBossRandomWord(),  wordSpawner.SpawnWord(12));
        words.Add(word);
        word = new Word(wordGenerator.GetBossRandomWord(),  wordSpawner.SpawnWord(13));
        words.Add(word);
        Monster monster = monsterSpawner.SpawnMonster(11);
        monsters.Add(monster);
        monsterCount++;
        if(monsterCount >= maximumMonster){
            monsterCount = 0;
        }
    }

    //When typing function
    public void TypeLetter (char letter)
    {
        StatManager.Instance.AddTypedEntries();
        //For typing activeword
        if(hasActiveWord)
        {
            //If the typing letter match the activeword, type the letter to the word 
            // (Remove the letter and move to the next letter in the word)
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
            else
            {
                StatManager.Instance.AddErrors();
            }
        }
        //When finish the whole activeword, change hasactiveword to false and remove activeword from the "words" list
        if(hasActiveWord && activeWord.WordTyped() && !BossMode)
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            StartCoroutine(monsters[0].RemoveMonster());
            // monsters[0].RemoveMonster();
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
        } else if(hasActiveWord && activeWord.WordTyped() && BossMode)
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            AddNewMonster = true;
            if(words.Count == 0)
            {
                StartCoroutine(monsters[0].RemoveMonster());
                // monsters[0].RemoveMonster();
                monsters.RemoveAt(0);
            }
        }
        //if(WaveManager._isGameRun)
        StatManager.Instance.CalculateStatistic();
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
