using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Monster Attack time and wave setting
public class WaveManager : MonoBehaviour
{
    public WordManager WordManager;
    //Setting maximum number per wave
    public int maximumMonsterPerWave = 10;
    //Number of the current monster defeat in the wave
    public int monsterCount = 0;
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
        Debug.Log(_remainingTime);
        //if it time to attack
        if(_isGameRun && WordManager.hasActiveWord && _remainingTime >= _idleTime)
        {
            WordManager.activeMonster.Attack();
            _remainingTime -= (_remainingTime + _attackingTime);
            
        }else if(_isGameRun && WordManager.hasActiveWord && _remainingTime >= (_idleTime - _warningTime)) 
        {
            warning += Time.deltaTime;

            if(!warnSwitch && warning > _warningTime/_warningfrequency)
            {
                warning = 0f;
                warnSwitch = true;
                WordManager.activeMonster.Attack();
            }
            else if(warnSwitch && warning > _warningTime/_warningfrequency)
            {
                warning = 0f;
                warnSwitch = false;
                WordManager.activeMonster.Active();
            }

        }else if(_isGameRun && WordManager.hasActiveWord && _remainingTime >= 0f)
        {
            //how long enemy stay in attack
            WordManager.activeMonster.Active();
            warning = 0f;
            warnSwitch = false;
        }

        if(!_isGameRun && numberOfWaveCount <= maximumWave)
        {
            cooldown += Time.deltaTime;
            if(cooldown > waveCoolDown)
            {
                WordManager.AddWord();
                _isGameRun = true;
                Reset();
            }
        }

        if(numberOfWaveCount <= maximumWave)
        {
            _remainingTime += Time.deltaTime;
        }
    }

    public void Reset()
    {
        _remainingTime = 0f;
        warnSwitch = false;
        warning = 0f;
    }

    public void NextWave()
    {
        Reset();
        numberOfWaveCount++;
        monsterCount = 0;
        cooldown = 0f;
        _isGameRun = false;
    }
}
