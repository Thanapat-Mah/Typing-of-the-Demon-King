using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public AudioSource NormalWave;
    public AudioSource BossWave;
    public WordManager WordManager;
    // Start is called before the first frame update
    void Start()
    {
        NormalWave.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(WordManager.BossMode)
        {
            if(NormalWave.isPlaying)
            {
                NormalWave.Stop();
            }
            if(!BossWave.isPlaying)
            {
                BossWave.Play();
            }
        }
    }
}
