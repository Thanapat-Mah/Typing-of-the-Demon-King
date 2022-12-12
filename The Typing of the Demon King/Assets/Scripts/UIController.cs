using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public WordManager WordManager;
    public WaveManager WaveManager;
    public TextMeshProUGUI remainingMonsterText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI WPMText;
    public TextMeshProUGUI coolDownText;
    public GameObject cooldown;
    public TextMeshProUGUI AccuracyText;
    private float TempCoolDown;
    private int TempmonsterRemain;
    

    // Start is called before the first frame update
    void Start()
    {
        cooldown.SetActive(false);
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
    }
}
