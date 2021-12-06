using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShurilkenContainerUI : MonoBehaviour
{

    public GameObject shurikenIconPrefab;

    void Start()
    {
        UpdateIcons();

        GameEvents.instance.onShurikenCountChange += UpdateIcons;
    }

    void OnDelete()
    {
        GameEvents.instance.onShurikenCountChange -= UpdateIcons;
    }

    void UpdateIcons()
    {
        CornerIconUI[] shurikenIcons = GetComponentsInChildren<CornerIconUI>();
        int existingIconCount = shurikenIcons.Length;
        int newIconCount = ShurikenSpawner.instance.maxAmount;

        if (existingIconCount < newIconCount)
        {
            for (int i = 0; i < newIconCount - existingIconCount; i++)
            {
                Instantiate(shurikenIconPrefab, transform);
            }
        }

        for (int i = 0; i < existingIconCount; i++)
        {
            if (i < ShurikenSpawner.instance.currentAmount)
            {
                shurikenIcons[i].SetUnused();
            }
            else if (i < ShurikenSpawner.instance.maxAmount)
            {
                shurikenIcons[i].SetUsed();
            }
            else
            {
                shurikenIcons[i].Hide();
            }
        }


    }
}
