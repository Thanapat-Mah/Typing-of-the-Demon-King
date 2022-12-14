using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    // public ChangeScene ChangeScene;
    public WordManager WordManager;
    public WaveManager WaveManager;
    public MonsterManager MonsterManager;
    public TextMeshProUGUI remainingMonsterText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI WPMText;
    public TextMeshProUGUI coolDownText;
    public GameObject cooldown;
    public TextMeshProUGUI AccuracyText;
    public GameObject blood;
    private Animator bloodAnimator;
    private float TempCoolDown;
    private int TempmonsterRemain;
    //How long player stay in bloodOverlay
    public float bloodOverlay = 4f;
    //How long player stay in bloodOverlay
    private float tempTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        cooldown.SetActive(false);
        bloodAnimator = blood.GetComponent<Animator>();
        // SetBloodOverlayAlpha(0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!WordManager.BossMode && WaveManager._isGameRun)
        {
            waveText.gameObject.SetActive(true);
            remainingMonsterText.gameObject.SetActive(true);
            if(cooldown)
            {
                cooldown.SetActive(false);
            }
            TempmonsterRemain = WordManager.maximumMonsterPerWave - WordManager.AllmonsterCount;
        }
        else if(!WordManager.BossMode && !WaveManager._isGameRun)
        {
            cooldown.SetActive(true);
            TempCoolDown = WaveManager.waveCoolDown-WaveManager.cooldown;
            TempmonsterRemain = 0;
            waveText.gameObject.transform.parent.gameObject.SetActive(false);
            remainingMonsterText.gameObject.transform.parent.gameObject.SetActive(false);
            // waveText.text = "Waiting for Next Wave";
        } else {
            if(cooldown)
            {
                // ChangeScene.FadeOut();
                cooldown.SetActive(false);
            }
            // waveText.text = "Boss";
        }
        AccuracyText.text = StatManager.Instance.GetAccuracy().ToString()+" %";
        WPMText.text = StatManager.Instance.GetRawWpm().ToString();
        waveText.text = WaveManager.numberOfWaveCount.ToString();
        coolDownText.text = TempCoolDown.ToString("F0")+" Sec";
        remainingMonsterText.text = TempmonsterRemain.ToString();

        if(MonsterManager.hurt || WordManager.missSpell)
        {
            bloodAnimator.SetBool("fade_in", true);
            // Debug.Log("hurt");
            // float temp = 63.75f*tempTime;
            tempTime += Time.deltaTime;
            // float alpha = 255f-temp;
            // SetBloodOverlayAlpha(alpha);
            // Debug.Log(blood.color);
            if(tempTime >= bloodOverlay)
            {
                bloodAnimator.SetTrigger("fade_out");
                bloodAnimator.SetBool("fade_in", false);
                if(MonsterManager.hurt)
                {
                    MonsterManager.hurt = false;
                }
                if(WordManager.missSpell)
                {
                    WordManager.missSpell = false;
                }
                tempTime = 0f;
            }
        } 
    }
}
