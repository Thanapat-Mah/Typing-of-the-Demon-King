using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private TextMeshProUGUI acc;
    [SerializeField] private TextMeshProUGUI timeUses;
    [SerializeField] private TextMeshProUGUI rawWpm;
    [SerializeField] private TextMeshProUGUI netWpm;
    [SerializeField] private TextMeshProUGUI entry;
    [SerializeField] private TextMeshProUGUI error;
    
    // Start is called before the first frame update
    void Start()
    {
        StatManager.Instance.CalculateAverageWaveStatistic();
        
        if (healthBar.GameOver)
        {
            result.SetText("Game Over");
            result.color = Color.red;
        }
        else if (WordManager.EasyBossDefeated)
        {
            result.SetText("COMPLETE EASY LEVEL");
            result.color = Color.green;
        }
        TimeManager.Instance.StopTimer();
        var time = TimeManager.Instance.GetTime();
        var minutes = Mathf.FloorToInt(time / 60);
        var seconds = Mathf.FloorToInt(time % 60);
        
        acc.SetText(StatManager.Instance.GetAverageWaveAccuracy().ToString());
        timeUses.SetText(minutes + "." + seconds);
        rawWpm.SetText(StatManager.Instance.GetAverageWaveRawWpm().ToString());
        netWpm.SetText(StatManager.Instance.GetAverageWaveNetWpm().ToString());
        entry.SetText(StatManager.Instance.GetTypeEntries().ToString());
        error.SetText(StatManager.Instance.GetErrors().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
