using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Monster Attack time and wave setting
public class WaveManager : MonoBehaviour
{
    // public ChangeScene ChangeScene;
    public WordManager WordManager;
    public KeyManager KeyManager;

    public GameObject bossBG;
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
        bossBG.SetActive(false);
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
            // StatManager.Instance.AddWaveStatistic();
            // TimeManager.Instance.StopTimer();
            var keyCollected = KeyManager.getKeyNum() >= KeyManager.getMaxKeyNum();
            cooldown += Time.deltaTime;
            if (cooldown > waveCoolDown - 1)
                if (keyCollected)
                    bossBG.SetActive(true);
            if(cooldown > waveCoolDown)
            {
                WordManager.AllmonsterCount = 0;
                //Check number of key
                if(keyCollected)
                {
                    KeyManager.ResetKey();
                    // ChangeScene.FadeIn();
                    StartBossWave();
                } else {
                    WordManager.AddWord();
                    WordManager.AddWord();
                }
                TimeManager.Instance.ContinueTimer();
                _isGameRun = true;
            }
        }
    }
    //go to next wave
    public void NextWave()
    {
        if(StatManager.Instance.GetRawWpm() >= 30 && StatManager.Instance.GetAccuracy() >= 85)
        {
            KeyManager.addKey();
        }
        numberOfWaveCount++;
        cooldown = 0f;
        StatManager.Instance.StartNewWave();
        _isGameRun = false;
    }

    public void StartBossWave()
    {
        StatManager.Instance.StartNewWave();
        WordManager.BossMode = true;
        WordManager.AddBossWord();
    }

    public int getWaveNum()
    {
        return numberOfWaveCount;
    }
}
