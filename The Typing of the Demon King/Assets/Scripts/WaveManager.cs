using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Monster Attack time and wave setting
public class WaveManager : MonoBehaviour
{
    public WordManager WordManager;
    //Number of the current wave
    public int numberOfWaveCount = 1;
    public float waveCoolDown = 10f;
    //Key the player get
    public int key = 0;
    //Maximum Key the player get for boss
    public int MaxKey = 3;


    //is the game running
    public bool _isGameRun;
    private float cooldown = 0f;
    private void Start()
    {
        _isGameRun = true;
        numberOfWaveCount = 1;
        cooldown = 0f;
    }
    private void Update()
    {
        ////////////////////////////////////for monster spawn and wave //////////////////////////////////
        //if it the end of the wave cooldown and go to next wave
        if(WordManager.EndOfWave)
        {
            NextWave();
            WordManager.EndOfWave = false;
        }

        // For cooldown after change wave ///////////////////////////////////////////////////////////////////////////////
        //if the wave is end (all monster is dead) cooldown the game
        if(!_isGameRun)
        {
            cooldown += Time.deltaTime;
            Debug.Log(cooldown);
            if(cooldown > waveCoolDown)
            {
                Debug.Log("EndCoolDown");
                WordManager.AllmonsterCount = 0;
                WordManager.AddWord();
                WordManager.AddWord();
                _isGameRun = true;
            }
        }
    }
    //go to next wave
    public void NextWave()
    {
        Debug.Log("NextWave");
        numberOfWaveCount++;
        cooldown = 0f;
        _isGameRun = false;
    }

    public int getWaveNum()
    {
        return numberOfWaveCount;
    }

    public void getKey()
    {
        key++;
    }
    public int getKeyNum()
    {
        return key;
    }
}
