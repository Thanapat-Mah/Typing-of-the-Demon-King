using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    
    private float _accuracy;
    
    private float _rawWpm;
    
    private float _netWpm;

    private float _typedEntries;
    
    private float _errors;

    private List<float> _waveAccuracyList = new List<float>();
    
    private List<float> _waveRawWpmList = new List<float>();
    
    private List<float> _waveNetWpmList = new List<float>();
    
    private float _averageWaveAccuracy = 0;
    
    private float _averageWaveRawWpm = 0;
    
    private float _averageWaveNetWpm = 0;
    
    private float _waveTypedEntries;
    
    private float _waveErrors;

    private float _waveTimeUsed;

    private List<float> _accuracyList = new List<float>();
    
    private List<float> _rawWpmList = new List<float>();
    
    private List<float> _netWpmList = new List<float>();

    private float _averageTotalAccuracy = 0;
    
    private float _averageTotalRawWpm = 0;
    
    private float _averageTotalNetWpm = 0;
    
    private float _totalTypedEntries;
    
    private float _totalErrors;

    public void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void Start()
    {
        // enabled = false;
    }
    
    private void Update()
    {
        if (_accuracy < 0) _accuracy = 0;
        if (_rawWpm < 0) _rawWpm = 0;
        if (_netWpm < 0) _netWpm = 0;
        if (_typedEntries < 0) _typedEntries = 0;
        if (_errors < 0) _errors = 0;
    }
    
    public void StartGame()
    {
        _accuracy = 0;
        _rawWpm = 0;
        _netWpm = 0;
        _typedEntries = 0;
        _errors = 0;
        _waveAccuracyList.Clear();
        _waveNetWpmList.Clear();
        _waveRawWpmList.Clear();
        TimeManager.Instance.StartTimer();
        enabled = true;
    }
    
    public void StartNewWave()
    {
        _accuracy = 0;
        _rawWpm = 0;
        _netWpm = 0;
        _typedEntries = 0;
        _errors = 0;
        TimeManager.Instance.StartTimer();
        enabled = true;
    }

    public void CalculateRawStatistic()
    {
        _accuracy = ((_typedEntries - _errors) / _typedEntries) * 100;
        _accuracy = Mathf.Round(_accuracy);
        
        _rawWpm = (_typedEntries / 5) / (TimeManager.Instance.GetTime() / 60);
        _rawWpm = (int)Mathf.Round(_rawWpm);
        
        _netWpm = ((_typedEntries / 5) - _errors) / (TimeManager.Instance.GetTime() / 60);
        _netWpm = (int)Mathf.Round(_netWpm);
    }

    public float GetAccuracy()
    {
        // Debug.Log("_accuracy = " + _accuracy);
        return _accuracy;
    }

    public float GetRawWpm()
    {
        // Debug.Log("_rawWpm = " + _rawWpm);
        return _rawWpm; 
    }
    
    public float GetNetWpm()
    {
        // Debug.Log("_netWpm = " + _netWpm);
        return _netWpm;
    }

    public void AddTypedEntries()
    {
        _typedEntries += 1;
    }
    
    public void AddErrors()
    {
        _errors += 1;
    }

    // public void AddAccuracyToList()
    // {
    //     _accuracyList.Add(_accuracy);
    // }
    //
    // public void AddRawWpmToList()
    // {
    //     _rawWpmList.Add(_rawWpm);
    // }
    //
    // public void AddNetWpmToList()
    // {
    //     _netWpmList.Add(_netWpm);
    // }

    public void AddWaveStatistic()
    {
        _waveAccuracyList.Add(_accuracy);
        //Debug.Log("add " + _accuracy + " to acc wave list");
        _waveRawWpmList.Add(_rawWpm);
        _waveNetWpmList.Add(_netWpm);
        _waveTypedEntries += _typedEntries;
        _waveErrors += _errors;
        _waveTimeUsed += TimeManager.Instance.GetTime();
    }
    
    public void CalculateAverageWaveStatistic()
    {
        _averageWaveAccuracy = Mathf.Round(_waveAccuracyList.Sum() / _waveAccuracyList.Count);
        _averageWaveRawWpm = Mathf.Round(_waveRawWpmList.Sum() / _waveRawWpmList.Count);
        _averageWaveNetWpm = Mathf.Round(_waveNetWpmList.Sum() / _waveNetWpmList.Count);
    }
    
    public float GetAverageWaveAccuracy()
    {
        return _averageTotalAccuracy;
    }

    public float GetAverageWaveRawWpm()
    {
        return _averageTotalRawWpm;
    }

    public float GetAverageWaveNetWpm()
    {
        return _averageTotalNetWpm;
    }

    public float GetWaveTypedEntries()
    {
        return _waveTypedEntries;
    }
    
    public float GetWaveErrors()
    {
        return _waveErrors;
    }
    
    public float GetTimeUsed()
    {
        return _waveTimeUsed;
    }

    public void CalculateAverageTotalStatistic()
    {
        _accuracyList.Add(_averageWaveAccuracy);
        _rawWpmList.Add(_averageWaveRawWpm);
        _netWpmList.Add(_averageWaveNetWpm);
        _totalTypedEntries += _waveTypedEntries;
        _totalErrors += _waveErrors;
        _averageTotalAccuracy = Mathf.Round(_accuracyList.Sum() / _accuracyList.Count);
        _averageTotalRawWpm = Mathf.Round(_rawWpmList.Sum() / _rawWpmList.Count);
        _averageTotalNetWpm = Mathf.Round(_netWpmList.Sum() / _netWpmList.Count);
    }

    public float GetAverageTotalAccuracy()
    {
        return _averageTotalAccuracy;
    }

    public float GetAverageTotalRawWpm()
    {
        return _averageTotalRawWpm;
    }

    public float GetAverageTotalNetWpm()
    {
        return _averageTotalNetWpm;
    }
    
    public float GetMaxTotalAccuracy()
    {
        return _accuracyList.Max();
    }

    public float GetMaxTotalRawWpm()
    {
        return _rawWpmList.Max();
    }

    public float GetMaxTotalNetWpm()
    {
        return _netWpmList.Max();
    }
    
    public float GetTypeEntries()
    {
        return _typedEntries;
    }
    
    public float GetErrors()
    {
        return _errors;
    }
    
    public float GetTotalTypeEntries()
    {
        return _totalTypedEntries;
    }
    
    public float GetTotalErrors()
    {
        return _totalErrors;
    }
}