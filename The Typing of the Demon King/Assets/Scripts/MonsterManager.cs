using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public WordManager WordManager;
    public WaveManager WaveManager;
    public healthBar healthBar;
    //How long enemy wait before attack
    public float _idleTime = 10f;
    //How long enemy warn player before attack
    public float _warningTime = 1f;
    //How long enemy warn player before attack
    public float _warningfrequency = 4f;
    public bool hurt = false;
    public int monsterDamage = 10;
    public int BossDamage = 20;
    private float AttackTime;

    //parameter for counting time
    private static float _remainingTime;
    private bool warnSwitch = false;
    private float warning = 0f;

    private void Start()
    {
        _remainingTime = 0f;
        warnSwitch = false;
        warning = 0f;
        hurt = false;
    }

    private void Update()
    {
        // StartCoroutine(MonsterAttack());
        if(WaveManager._isGameRun)
        {
            _remainingTime += Time.deltaTime;
        }
        
        ////////////////////////////////////for monster warning and attack //////////////////////////////////
        //if it time to attack
        if(WaveManager._isGameRun && WordManager.hasActiveWord && _remainingTime >= _idleTime)
        {
            WordManager.activeMonster.Attack();
            WordManager.activeMonster.AttackAnimation();
            // AttackTime = WordManager.activeMonster.GetAttackAnimationLength();
            if(WordManager.BossMode)
            {
                healthBar.DamageHealth(BossDamage);
                Debug.Log("damaged from boss");
            }
            else
            {
                healthBar.DamageHealth(monsterDamage);
                Debug.Log("damaged from monster");

            }
            hurt = true;
            _remainingTime -=_remainingTime;
        //if it almost attack time do a warning
        }else if(WaveManager._isGameRun && WordManager.hasActiveWord && _remainingTime >= (_idleTime - _warningTime)) 
        {
            //count for warning
            warning += Time.deltaTime;
            //if the warnswitch is off and warning is in the frequency turn it on and set the state of monster to attack(red)
            if(!warnSwitch && warning > _warningTime/_warningfrequency)
            {
                warning = 0f;
                warnSwitch = true;
                WordManager.activeMonster.Attack();
            }
            //if the warnswitch is on and warning is in the frequency turn it off and set the state of monster to active(orange)
            else if(warnSwitch && warning > _warningTime/_warningfrequency)
            {
                warning = 0f;
                warnSwitch = false;
                WordManager.activeMonster.Active();
            }
        //if it is in the attack time stay in attack
        }else if(WaveManager._isGameRun && WordManager.hasActiveWord && _remainingTime >= 0f)
        {
            //how long enemy stay in attack
            WordManager.activeMonster.Active();
            warning = 0f;
            warnSwitch = false;
        }
        
        if(!WaveManager._isGameRun)
        {
            Reset();
        }
        
        //if the monster is dead reset the clock for another monster attack
        if(WordManager.AddNewMonster)
        {
            Reset();
            WordManager.AddNewMonster = false;
        }
    }

    // private IEnumerator MonsterAttack()
    // {
    //     if(WaveManager._isGameRun)
    //     {
    //         _remainingTime += Time.deltaTime;
    //     }
    //     
    //     ////////////////////////////////////for monster warning and attack //////////////////////////////////
    //     //if it time to attack
    //     if(WaveManager._isGameRun && WordManager.hasActiveWord && _remainingTime >= _idleTime)
    //     {
    //         WordManager.activeMonster.Attack();
    //         WordManager.activeMonster.AttackAnimation();            
    //         if(WordManager.BossMode)
    //         {
    //             yield return new WaitForSeconds(WordManager.activeMonster.GetAttackAnimationLength());
    //             healthBar.DamageHealth(BossDamage);
    //         }
    //         else
    //         {
    //             yield return new WaitForSeconds(WordManager.activeMonster.GetAttackAnimationLength());
    //             healthBar.DamageHealth(monsterDamage);
    //         }
    //         hurt = true;
    //         _remainingTime -=_remainingTime;
    //     //if it almost attack time do a warning
    //     }else if(WaveManager._isGameRun && WordManager.hasActiveWord && _remainingTime >= (_idleTime - _warningTime)) 
    //     {
    //         //count for warning
    //         warning += Time.deltaTime;
    //         //if the warnswitch is off and warning is in the frequency turn it on and set the state of monster to attack(red)
    //         if(!warnSwitch && warning > _warningTime/_warningfrequency)
    //         {
    //             warning = 0f;
    //             warnSwitch = true;
    //             WordManager.activeMonster.Attack();
    //         }
    //         //if the warnswitch is on and warning is in the frequency turn it off and set the state of monster to active(orange)
    //         else if(warnSwitch && warning > _warningTime/_warningfrequency)
    //         {
    //             warning = 0f;
    //             warnSwitch = false;
    //             WordManager.activeMonster.Active();
    //         }
    //     //if it is in the attack time stay in attack
    //     }else if(WaveManager._isGameRun && WordManager.hasActiveWord && _remainingTime >= 0f)
    //     {
    //         //how long enemy stay in attack
    //         WordManager.activeMonster.Active();
    //         warning = 0f;
    //         warnSwitch = false;
    //     }
    //
    //     if(!WaveManager._isGameRun)
    //     {
    //         Reset();
    //     }
    //
    //     //if the monster is dead reset the clock for another monster attack
    //     if(WordManager.AddNewMonster)
    //     {
    //         Reset();
    //         WordManager.AddNewMonster = false;
    //     }
    //
    //     yield return 0;
    // }

    //Reset attack time
    public void Reset()
    {
        _remainingTime = 0f;
        warnSwitch = false;
        warning = 0f;
    }
}
