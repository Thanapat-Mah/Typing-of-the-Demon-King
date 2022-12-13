using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    
    private float _accuracy;
    
    private float _rawWpm;
    
    private float _netWpm;
    
    private float _maxAccuracy = 0;
    
    private float _maxRawWpm = 0;
    
    private float _maxNetWpm = 0;

    private float _typedEntries;
    
    private float _errors;
    
    private float _totalTypedEntries;
    
    private float _totalErrors;
    
    private float _averageAccuracy = 0;
    
    private float _averageRawWpm = 0;
    
    private float _averageNetWpm = 0;

    private List<float> _accuracyList = new List<float>();
    
    private List<float> _rawWpmList = new List<float>();
    
    private List<float> _netWpmList = new List<float>();

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
        
    }
    
    public void StartCalculateStatistic()
    {
        _rawWpm = 0;
        _netWpm = 0;
        _accuracy = 100;
        _typedEntries = 0;
        _errors = 0;
        enabled = true;
    }

    public void CalculateStatistic()
    {
        _accuracy = ((_typedEntries - _errors) / _typedEntries) * 100;
        _accuracy = Mathf.Round(_accuracy);
        if (_accuracy > _maxAccuracy)
            _maxAccuracy = _accuracy;
        
        _rawWpm = (_typedEntries / 5) / (TimeManager.Instance.GetTime() / 60);
        _rawWpm = (int)Mathf.Round(_rawWpm);
        if (_rawWpm > _maxRawWpm)
            _maxRawWpm = _rawWpm;
        
        _netWpm = ((_typedEntries / 5) - _errors) / (TimeManager.Instance.GetTime() / 60);
        _netWpm = (int)Mathf.Round(_netWpm);
        if (_netWpm > _maxNetWpm)
            _maxNetWpm = _netWpm;
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
    
    public float GetMaxAccuracy()
    {
        // Debug.Log("_accuracy = " + _accuracy);
        return _maxAccuracy;
    }

    public float GetMaxRawWpm()
    {
        // Debug.Log("_rawWpm = " + _rawWpm);
        return _maxRawWpm; 
    }
    
    public float GetMaxNetWpm()
    {
        // Debug.Log("_netWpm = " + _netWpm);
        return _maxNetWpm;
    }

    public void AddTypedEntries()
    {
        _typedEntries += 1;
        _totalTypedEntries += 1;
    }
    
    public void AddErrors()
    {
        _errors += 1;
        _totalErrors += 1;
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

    public void CalculateAverageStatistic()
    {
        _accuracyList.Add(_accuracy);
        _rawWpmList.Add(_rawWpm);
        _netWpmList.Add(_netWpm);
        _averageAccuracy = Mathf.Round(_accuracyList.Sum() / _accuracyList.Count);
        _averageRawWpm = Mathf.Round(_rawWpmList.Sum() / _rawWpmList.Count);
        _averageNetWpm = Mathf.Round(_netWpmList.Sum() / _netWpmList.Count);
    }

    public float GetAverageAccuracy()
    {
        return _averageAccuracy;
    }

    public float GetAverageRawWpm()
    {
        return _averageRawWpm;
    }

    public float GetAverageNetWpm()
    {
        return _averageNetWpm;
    }
    
    public float GetMaxOverallAccuracy()
    {
        return _accuracyList.Max();
    }

    public float GetMaxOverallRawWpm()
    {
        return _rawWpmList.Max();
    }

    public float GetMaxOverallNetWpm()
    {
        return _netWpmList.Max();
    }
}