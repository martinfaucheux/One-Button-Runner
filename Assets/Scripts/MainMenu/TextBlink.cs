using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextBlink : MonoBehaviour
{
    public float speed = 2f;
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        Color color = text.color;
        Color fadeOutColor = color;
        fadeOutColor.a = 0;
        LeanTween.value(gameObject, updateValueCallback, fadeOutColor, color, 1f).setLoopPingPong();
    }


    void updateValueCallback(Color val)
    {
        text.color = val;
    }
}
