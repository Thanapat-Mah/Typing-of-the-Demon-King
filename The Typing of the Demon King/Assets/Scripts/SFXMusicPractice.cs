using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMusicPractice : MonoBehaviour
{
    public AudioSource MonsterAttack;
    public AudioSource BossAttack;
    public AudioSource MonsterHurt;
    public AudioSource MissSpell;
    public AudioSource MonsterDied;
    public WordManager WordManager;

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
        if(WordManager.correctSpell)
        {
            MonsterHurt.Play();
            WordManager.correctSpell = false;
        }
        if(WordManager.missSpellSFX)
        {
            MissSpell.Play();
            WordManager.missSpellSFX = false;
        }
        if(WordManager.MonsterDied)
        {
            MonsterDied.Play();
            WordManager.MonsterDied = false;
        }
    }
}
