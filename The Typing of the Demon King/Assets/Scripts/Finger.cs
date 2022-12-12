using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    // Store child keys of this finger
    public Key[] keys;
    // Store wheter this finger is selected or not
    private bool _isSelected = false;

    void Start()
    {
        
    }

    void Update()
    {
        // Check wheter any of child key is selected or not
        _isSelected = IsChildSelected();
        RenderSprite();
    }

    // Toggle selection of all child key according to finger's current status
    void OnMouseDown()
    {
        // Toggle the selection of all child key
        _isSelected = !_isSelected;
        if (_isSelected)
        {
            SelectAllChild(true);
        }
        else
        {
            SelectAllChild(false);
        }
    }

    // Toggle the key selection of all child key
    void SelectAllChild(bool isSelect)
    {
        foreach (Key key in keys)
        {
            key.SetSelected(isSelect);
        }
    }

    // Check wheter each any individual key is selected or not.
    bool IsChildSelected()
    {
        foreach (Key key in keys)
        {
            if (key.IsSelected())
            {
                return true;
            }
        }
        return false;
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
