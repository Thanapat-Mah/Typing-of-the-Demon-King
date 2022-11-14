using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintFinger : MonoBehaviour
{
    // Text and variable for show the next letter to type
    private TextMeshProUGUI _nextLetterText;
    private char _nextLetter;

    // Reference to WordManager, to get next letter to type
    public WordManager wordManager;

    // Reference to each finger in hint panel
    public SpriteRenderer[] leftFingers;  // From palm(thumb) to little of left hand
    public SpriteRenderer[] rightFingers; // From palm(thumb) to little of right hand

    // Reference to current finger for next letter
    private int finger = 0;
    private char hand = 'l';

    // Hard-code config the character of each finger
    private char[] _leftIndex = { 't', 'g', 'b', 'r', 'f', 'v' };
    private char[] _leftMiddle = { 'e', 'd', 'c' };
    private char[] _leftRing = { 'w', 's', 'x' };
    private char[] _leftLittle = { 'q', 'a', 'z' };
    private char[] _rightIndex = { 'y', 'h', 'n', 'u', 'j', 'm' };
    private char[] _rightMiddle = { 'i', 'k', ',' };
    private char[] _rightRing = { 'o', 'l', '.' };
    private char[] _rightLittle = { 'p', '\'' };
    //{ , { 'e', 'd', 'c' }, { 'w', 's', 'x' }, { 'q', 'a', 'z' } };

    void Start()
    {
        _nextLetterText = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        // Color all finger as gray
        for (int li = 0; li < leftFingers.Length; li++)
        {
            leftFingers[li].color = Color.gray;
        }
        for (int ri = 0; ri < rightFingers.Length; ri++)
        {
            rightFingers[ri].color = Color.gray;
        }
    }

    void Update()
    {
        // show the next letter to type
        _nextLetter = wordManager.GetNextLetter();
        _nextLetterText.text = "" + _nextLetter;

        FindFinger();
        ColorFinger();
    }


    void FindFinger()
    {
        // Convert char to lowercase
        _nextLetter = char.ToLower(_nextLetter);

        hand = ' ';

        // Find wheter the next letter is in left hand
        foreach (char k in _leftIndex)
        {
            if (k == _nextLetter)
            {
                hand = 'l';
                finger = 1;
            }
        }
        foreach (char k in _leftMiddle)
        {
            if (k == _nextLetter)
            {
                hand = 'l';
                finger = 2;
            }
        }
        foreach (char k in _leftRing)
        {
            if (k == _nextLetter)
            {
                hand = 'l';
                finger = 3;
            }
        }
        foreach (char k in _leftLittle)
        {
            if (k == _nextLetter)
            {
                hand = 'l';
                finger = 4;
            }
        }
        // Find wheter the next letter is in right hand
        foreach (char k in _rightIndex)
        {
            if (k == _nextLetter)
            {
                hand = 'r';
                finger = 1;
            }
        }
        foreach (char k in _rightMiddle)
        {
            if (k == _nextLetter)
            {
                hand = 'r';
                finger = 2;
            }
        }
        foreach (char k in _rightRing)
        {
            if (k == _nextLetter)
            {
                hand = 'r';
                finger = 3;
            }
        }
        foreach (char k in _rightLittle)
        {
            if (k == _nextLetter)
            {
                hand = 'r';
                finger = 4;
            }
        }
    }

    void ColorFinger()
    {
        // Color all palm and finger as gray
        foreach (SpriteRenderer f in leftFingers)
        {
            f.color = Color.gray;
        }
        foreach (SpriteRenderer f in rightFingers)
        {
            f.color = Color.gray;
        }

        // Color the palm and finger for netxt letter as white
        if (hand == 'l')
        {
            leftFingers[0].color = Color.white;
            leftFingers[finger].color = Color.white;
        }
        else if (hand == 'r')
        {
            rightFingers[0].color = Color.white;
            rightFingers[finger].color = Color.white;
        }
    }
}
