using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeartContainerUI : MonoBehaviour
{

    public GameObject heartIconPrefab;
    public PingPongAnimator pingPongAnimator;
    private Health _healthComponent;
    private int _previousValue;
    void Start()
    {
        _healthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        UpdateIcons();

        GameEvents.instance.onPlayerHealthChange += UpdateIcons;
    }

    void OnDelete()
    {
        GameEvents.instance.onPlayerHealthChange -= UpdateIcons;
    }

    void UpdateIcons()
    {
        CornerIconUI[] heartIcons = GetComponentsInChildren<CornerIconUI>();
        int existingIconCount = heartIcons.Length;
        int newIconCount = _healthComponent.maxHealth;

        if (existingIconCount < newIconCount)
        {
            for (int i = 0; i < newIconCount - existingIconCount; i++)
            {
                Instantiate(heartIconPrefab, transform);
            }
        }

        for (int i = 0; i < existingIconCount; i++)
        {
            if (i < _healthComponent.currentHealth)
            {
                heartIcons[i].SetUnused();
            }
            else if (i < _healthComponent.maxHealth)
            {
                heartIcons[i].SetUsed();
            }
            else
            {
                heartIcons[i].Hide();
            }
        }
        if (_healthComponent.currentHealth < _previousValue)
        {
            pingPongAnimator.Animate();
        }
        _previousValue = _healthComponent.currentHealth;
    }
}
