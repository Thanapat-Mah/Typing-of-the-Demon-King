using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public GameObject[] keyImage;
    //Key the player get
    private int key = 0;
    //Maximum Key the player get for boss
    private int MaxKey = 3;
    public bool _isGetKey = false;
    // Start is called before the first frame update
    void Start()
    {
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < keyImage.Length; i++)
        {
            if(key > i)
            {
                keyImage[i].SetActive(true);
            } 
            else 
            {
                keyImage[i].SetActive(false);
            }
        }
    }
    public void addKey()
    {
        _isGetKey = true;
        key++;
    }

    public int getKeyNum()
    {
        return key;
    }

    public int getMaxKeyNum()
    {
        return MaxKey;
    }
    
    public void ResetKey()
    {
        key = 0;
    }
}
