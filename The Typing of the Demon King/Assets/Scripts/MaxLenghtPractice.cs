using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaxLenghtPractice : MonoBehaviour
{
    private static MaxLenghtPractice Instance;
    private static int maxLenght = 3;

    private static TextMeshProUGUI maxLenghtText;
    private static Slider maxLenghtSlider;

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

    void Start()
    {
        maxLenghtText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        maxLenghtSlider = gameObject.GetComponentInChildren<Slider>();
        maxLenghtSlider.value = maxLenght;
    }

    void Update()
    {
        maxLenght = (int) maxLenghtSlider.value;
        maxLenghtText.text = "Max Lenght Word  " + maxLenght;
    }

    public static int GetMaxLenght()
    {
        return (int) maxLenghtSlider.value;
    }
}
