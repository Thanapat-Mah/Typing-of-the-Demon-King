using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    
    private int _grossWpm;
    
    private int _netWpm;
    
    private int _accuracy;
    
    private int _typedEntries;
    
    private int _errors;

    public void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    
    private void Start()
    {
        enabled = false;
    }
    
    private void Update()
    {
        CalculateAccuracy();
        CalculateGrossWpm();
        CalculateNetWpm();
    }

    private void CalculateAccuracy()
    {
        var acc = (_typedEntries - _errors) / _typedEntries * 100;
        _accuracy = (int)Mathf.Round(acc);
    }

    private void CalculateGrossWpm()
    {
        var grossWpm = (_typedEntries / 5) / (TimeManager.Instance.GetTime() / 60);
        _grossWpm = (int)Mathf.Round(grossWpm);
    }
    
    private void CalculateNetWpm()
    {
        var netWpm = ((_typedEntries / 5) - _errors) / (TimeManager.Instance.GetTime() / 60);
        _netWpm = (int)Mathf.Round(netWpm);
    }

    public void SetTypedEntries(int typeEntries)
    {
        _typedEntries = typeEntries;
    }
    
    public void SetErrors(int errors)
    {
        _errors = errors;
    }
    
    public int GetAccuracy()
    {
        return _accuracy;
    }
    
    public int GetGrossWpm()
    {
        return _grossWpm;
    }
    
    public int GetNetWpm()
    {
        return _netWpm;
    }

}