using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Monster Attack time and wave setting
public class WaveManager : MonoBehaviour
{
    public WordManager WordManager;
    //Number of the current wave
    public int numberOfWaveCount = 1;
    //Number of the maximum wave
    public int maximumWave = 3;
    public float waveCoolDown = 10f;
    //How long enemy wait before attack
    public float _idleTime = 10f;
    //How long enemy stay in attack mode
    public float _attackingTime = 5f;
    //How long enemy warn player before attack
    public float _warningTime = 1f;
    //How long enemy warn player before attack
    public float _warningfrequency = 4f;
    //Key the player get
    public int key = 0;
    //Maximum Key the player get for boss
    public int MaxKey = 3;


    //is the game running
    private static bool _isGameRun;
    //parameter for counting time
    private static float _remainingTime;
    private bool warnSwitch = false;
    private float warning = 0f;
    private float cooldown = 0f;
    private void Start()
    {
        _isGameRun = true;
        _remainingTime = 0f;
        numberOfWaveCount = 1;
        warnSwitch = false;
        warning = 0f;
        cooldown = 0f;
    }
    private void Update()
    {
        if(_isGameRun)
        {
            _remainingTime += Time.deltaTime;
        }
        
        ////////////////////////////////////for monster warning and attack //////////////////////////////////
        //if it time to attack
        if(_isGameRun && WordManager.hasActiveWord && _remainingTime >= _idleTime)
        {
            WordManager.activeMonster.Attack();
            _remainingTime -= (_remainingTime + _attackingTime);
        //if it almost attack time do a warning
        }else if(_isGameRun && WordManager.hasActiveWord && _remainingTime >= (_idleTime - _warningTime)) 
        {
            //count for warning
            warning += Time.deltaTime;
            //if the warnswitch is off and warning is in the frequency turn it on and set the state of monster to attack(red)
            if(!warnSwitch && warning > _warningTime/_warningfrequency)
            {
                warning = 0f;
                warnSwitch = true;
                WordManager.activeMonster.Attack();
            //if the warnswitch is on and warning is in the frequency turn it off and set the state of monster to active(orange)
            }
            else if(warnSwitch && warning > _warningTime/_warningfrequency)
            {
                warning = 0f;
                warnSwitch = false;
                WordManager.activeMonster.Active();
            }
        //if it is in the attack time stay in attack
        }else if(_isGameRun && WordManager.hasActiveWord && _remainingTime >= 0f)
        {
            //how long enemy stay in attack
            WordManager.activeMonster.Active();
            warning = 0f;
            warnSwitch = false;
        }

        ////////////////////////////////////for monster spawn and wave //////////////////////////////////
        //if the monster is dead reset the clock for attack
        if(WordManager.AddNewMonster)
        {
            Reset();
            WordManager.AddNewMonster = false;
        }

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
                Reset();
            }
        }
    }

    //Reset attack time
    public void Reset()
    {
        _remainingTime = 0f;
        warnSwitch = false;
        warning = 0f;
    }
    //go to next wave
    public void NextWave()
    {
        Debug.Log("NextWave");
        Reset();
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
