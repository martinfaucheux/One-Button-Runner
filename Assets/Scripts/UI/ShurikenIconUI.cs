using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenIconUI : MonoBehaviour
{
    public Image image;

    public void Hide()
    {
        SetAlpha(0f);
    }

    public void SetUnused()
    {
        SetAlpha(1f);
    }
    public void SetUsed()
    {
        SetAlpha(0.35f);
    }

    private void SetAlpha(float value)
    {
        Color color = image.color;
        color.a = value;
        image.color = color;
    }
}
