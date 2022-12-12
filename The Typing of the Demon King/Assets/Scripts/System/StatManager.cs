using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    
    private float _accuracy;
    
    private float _grossWpm;
    
    private float _netWpm;
    
    private float _maxAccuracy = 0;
    
    private float _maxGrossWpm = 0;
    
    private float _maxNetWpm = 0;

    private float _typedEntries;
    
    private float _errors;
    
    private float _totalTypedEntries;
    
    private float _totalErrors;
    
    private float _averageAccuracy = 0;
    
    private float _averageGrossWpm = 0;
    
    private float _averageNetWpm = 0;

    private List<float> _accuracyList = new List<float>();
    
    private List<float> _grossWpmList = new List<float>();
    
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
        _grossWpm = 0;
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
        
        _grossWpm = (_typedEntries / 5) / (TimeManager.Instance.GetTime() / 60);
        _grossWpm = (int)Mathf.Round(_grossWpm);
        if (_grossWpm > _maxGrossWpm)
            _maxGrossWpm = _grossWpm;
        
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

    public float GetGrossWpm()
    {
        // Debug.Log("_grossWpm = " + _grossWpm);
        return _grossWpm; 
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

    public float GetMaxGrossWpm()
    {
        // Debug.Log("_grossWpm = " + _grossWpm);
        return _maxGrossWpm; 
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
    // public void AddGrossWpmToList()
    // {
    //     _grossWpmList.Add(_grossWpm);
    // }
    //
    // public void AddNetWpmToList()
    // {
    //     _netWpmList.Add(_netWpm);
    // }

    public void CalculateAverageStatistic()
    {
        _accuracyList.Add(_accuracy);
        _grossWpmList.Add(_grossWpm);
        _netWpmList.Add(_netWpm);
        _averageAccuracy = Mathf.Round(_accuracyList.Sum() / _accuracyList.Count);
        _averageGrossWpm = Mathf.Round(_grossWpmList.Sum() / _grossWpmList.Count);
        _averageNetWpm = Mathf.Round(_netWpmList.Sum() / _netWpmList.Count);
    }

    public float GetAverageAccuracy()
    {
        return _averageAccuracy;
    }

    public float GetAverageGrossWpm()
    {
        return _averageGrossWpm;
    }

    public float GetAverageNetWpm()
    {
        return _averageNetWpm;
    }
    
    public float GetMaxOverallAccuracy()
    {
        return _accuracyList.Max();
    }

    public float GetMaxOverallGrossWpm()
    {
        return _grossWpmList.Max();
    }

    public float GetMaxOverallNetWpm()
    {
        return _netWpmList.Max();
    }
}