using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string key;
    private bool _isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        RenderSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetKey()
    {
        return key;
    }

    public bool IsSelected()
    {
        return _isSelected;
    }

    void OnMouseDown()
    {
        // Toggle the selection of the key
        _isSelected = !_isSelected;
        RenderSprite();
        Debug.Log(key);
    }

    void RenderSprite()
    {
        if (_isSelected)
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}
