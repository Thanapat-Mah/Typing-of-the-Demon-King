using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public WordManager WordManager;
    public WaveManager WaveManager;
    public MonsterManager MonsterManager;
    public TextMeshProUGUI remainingMonsterText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI WPMText;
    public TextMeshProUGUI coolDownText;
    public GameObject cooldown;
    public TextMeshProUGUI AccuracyText;
    public SpriteRenderer blood;
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
        SetBloodOverlayAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!WordManager.BossMode && WaveManager._isGameRun)
        {
            if(cooldown)
            {
                cooldown.SetActive(false);
            }
            TempmonsterRemain = WordManager.maximumMonsterPerWave - WordManager.AllmonsterCount;
            waveText.text = WaveManager.numberOfWaveCount.ToString();
            remainingMonsterText.text = TempmonsterRemain.ToString();
        }
        else if(!WordManager.BossMode && !WaveManager._isGameRun)
        {
            cooldown.SetActive(true);
            TempCoolDown = WaveManager.waveCoolDown-WaveManager.cooldown;
            waveText.text = "Waiting for Next Wave";
            coolDownText.text = TempCoolDown.ToString("F0")+" Sec";
        } else {
            if(cooldown)
            {
                cooldown.SetActive(false);
            }
            waveText.text = "Boss";
        }
        AccuracyText.text = StatManager.Instance.GetAccuracy().ToString()+" %";
        WPMText.text = StatManager.Instance.GetNetWpm().ToString();

        if(MonsterManager.hurt)
        {
            float temp = 63.75f*tempTime;
            float alpha = 255f-temp;
            SetBloodOverlayAlpha(alpha);
            Debug.Log(blood.color);
            tempTime += Time.deltaTime;
            if(tempTime >= bloodOverlay)
            {
                MonsterManager.hurt = false;
                tempTime = 0f;
            }
        } 
    }

    public void SetBloodOverlayAlpha(float value)
    {
        Color tmp = blood.color;
        tmp.a = value;
        blood.color = tmp;
    }
}
