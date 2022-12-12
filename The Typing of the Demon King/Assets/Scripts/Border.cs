using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Border : MonoBehaviour
{
    public Image Image;
    // Start is called before the first frame update
    public Sprite inactiveSprite;
    public Sprite activeSprite;
    public Sprite attackSprite;

    public void SetActive ()
    {
        Image.sprite = activeSprite;
    }

    public void SetInactive ()
    {
        Image.sprite = inactiveSprite;
    }

    public void SetAttack ()
    {
        Image.sprite = attackSprite;
    }
}
