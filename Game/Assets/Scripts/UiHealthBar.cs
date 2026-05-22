using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UiHealthBar : MonoBehaviour
{
    public static UiHealthBar Instance { get; private set; }

    public Image mask;
    private float originalSize;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.sizeDelta.x;
    }

    void Update()
    {
        //SetValue(0.5f);    
    }

    public void SetValue(float value)
    {
        value = Mathf.Clamp01(value);
        mask.rectTransform.sizeDelta = new Vector2(originalSize * value, mask.rectTransform.sizeDelta.y);
    }
}
