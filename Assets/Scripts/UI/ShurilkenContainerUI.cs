using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShurilkenContainerUI : MonoBehaviour
{

    public GameObject shurikenIconPrefab;
    ShurikenSpawner _shurikenSpawner;

    void Start()
    {
        _shurikenSpawner = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ShurikenSpawner>();
        UpdateIcons();

        GameEvents.instance.onShurikenCountChange += UpdateIcons;
    }

    void OnDelete()
    {
        GameEvents.instance.onShurikenCountChange -= UpdateIcons;
    }

    void UpdateIcons()
    {
        ShurikenIconUI[] shurikenIcons = GetComponentsInChildren<ShurikenIconUI>();
        int existingIconCount = shurikenIcons.Length;
        int newIconCount = _shurikenSpawner.maxAmount;

        if (existingIconCount < newIconCount)
        {
            for (int i = 0; i < newIconCount - existingIconCount; i++)
            {
                Instantiate(shurikenIconPrefab, transform);
            }
        }

        for (int i = 0; i < existingIconCount; i++)
        {
            if (i < _shurikenSpawner.currentAmount)
            {
                shurikenIcons[i].SetUnused();
            }
            else if (i < _shurikenSpawner.maxAmount)
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
