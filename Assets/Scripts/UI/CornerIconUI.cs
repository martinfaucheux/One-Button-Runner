using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornerIconUI : MonoBehaviour
{
    public Image image;
    public Sprite emptySprite;
    private Sprite fullSprite;

    void Start()
    {
        fullSprite = image.sprite;
    }

    public void Hide()
    {
        SetAlpha(0f);
    }

    public void SetUnused()
    {
        SetAlpha(1f);
        image.sprite = fullSprite;
    }
    public void SetUsed()
    {
        if (emptySprite == null)
        {
            SetAlpha(0.35f);
        }
        else
        {
            SetAlpha(1f);
            image.sprite = emptySprite;
        }
    }

    private void SetAlpha(float value)
    {
        Color color = image.color;
        color.a = value;
        image.color = color;
    }
}
