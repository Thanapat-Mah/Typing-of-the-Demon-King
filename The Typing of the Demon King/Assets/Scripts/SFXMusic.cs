using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusic : MonoBehaviour
{
    public AudioSource PlayerHurt;
    public AudioSource MonsterAttack;
    public AudioSource GotKey;
    public AudioSource BossAttack;
    public AudioSource MonsterHurt;
    public AudioSource MissSpell;
    public AudioSource MonsterDied;
    public WordManager WordManager;
    public healthBar healthBar;
    public KeyManager KeyManager;

    // Update is called once per frame
    void Update()
    {
        if(WordManager.hasActiveWord)
        {
            if(WordManager.activeMonster._isAttack)
            {
                if(WordManager.BossMode)
                {
                    BossAttack.PlayDelayed(0.5f);
                }
                else
                {
                    MonsterAttack.PlayDelayed(0.5f);
                }
                WordManager.activeMonster._isAttack = false;
            }
        }
        if(healthBar._isDamage)
        {
            if(!WordManager.missSpellSFX)
            {
                PlayerHurt.PlayDelayed(0.5f);
            }
            healthBar._isDamage = false;
        }
        if(KeyManager._isGetKey)
        {
            GotKey.Play();
            KeyManager._isGetKey = false;
        }
        if(WordManager.correctSpell)
        {
            MonsterHurt.Play();
            WordManager.correctSpell = false;
        }
        if(WordManager.missSpellSFX)
        {
            MissSpell.Play();
            PlayerHurt.Play();
            WordManager.missSpellSFX = false;
        }
        if(WordManager.MonsterDied)
        {
            MonsterDied.Play();
            WordManager.MonsterDied = false;
        }
    }
}
