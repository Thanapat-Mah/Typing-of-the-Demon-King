using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    
    private float _time;

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
        enabled = false;
    }
    
    private void Update()
    {
        if (enabled)
        {
            _time += Time.deltaTime;
        }
        // Debug.Log(_time);
    }
    
    public void StartTimer()
    {
        _time = 0;
        enabled = true;
    }
    
    public void StopTimer()
    {
        enabled = false;
    }
    
    public void ContinueTimer()
    {
        enabled = true;
    }
    
    public float GetTime()
    {
        return _time;
    }
}