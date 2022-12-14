using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI avgAcc;
    [SerializeField] private TextMeshProUGUI rawWpm;
    [SerializeField] private TextMeshProUGUI topNetWpm;
    [SerializeField] private TextMeshProUGUI netWpm;
    [SerializeField] private TextMeshProUGUI entry;
    [SerializeField] private TextMeshProUGUI error;
    // Start is called before the first frame update
    void Start()
    {
        avgAcc.SetText(StatManager.Instance.GetAverageTotalAccuracy().ToString());
        rawWpm.SetText(StatManager.Instance.GetAverageTotalRawWpm().ToString());
        topNetWpm.SetText(StatManager.Instance.GetMaxTotalNetWpm().ToString());
        netWpm.SetText(StatManager.Instance.GetAverageTotalNetWpm().ToString());
        entry.SetText(StatManager.Instance.GetTotalTypeEntries().ToString());
        error.SetText(StatManager.Instance.GetTotalErrors().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
