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
        RenderSprite();
    }

    public string GetKey()
    {
        return key;
    }

    public bool IsSelected()
    {
        return _isSelected;
    }

    public void SetSelected(bool isSelect)
    {
        _isSelected = isSelect;
    }

    // Toggle the selection of the key
    void OnMouseDown()
    {
        _isSelected = !_isSelected;
        RenderSprite();
        Debug.Log(key);
    }

    // Render the sprite color according to its status
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
