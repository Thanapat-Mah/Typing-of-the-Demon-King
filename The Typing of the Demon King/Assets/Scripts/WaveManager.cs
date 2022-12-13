using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Monster Attack time and wave setting
public class WaveManager : MonoBehaviour
{
    public WordManager WordManager;
    public KeyManager KeyManager;
    //Number of the current wave
    public int numberOfWaveCount = 1;
    public float waveCoolDown = 10f;

    //is the game running
    public bool _isGameRun;
    public float cooldown = 0f;
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
            if(cooldown > waveCoolDown)
            {
                WordManager.AllmonsterCount = 0;
                //Check number of key
                if(KeyManager.getKeyNum() == KeyManager.getMaxKeyNum())
                {
                    StartBossWave();
                } else {
                    WordManager.AddWord();
                    WordManager.AddWord();
                }
                _isGameRun = true;
            }
        }
    }
    //go to next wave
    public void NextWave()
    {
        numberOfWaveCount++;
        cooldown = 0f;
        _isGameRun = false;
    }

    public void StartBossWave()
    {
        WordManager.BossMode = true;
        WordManager.AddBossWord();
    }

    public int getWaveNum()
    {
        return numberOfWaveCount;
    }
}
