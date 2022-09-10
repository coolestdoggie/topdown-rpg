using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText
{
    private bool isActive;
    private GameObject gameObject;
    private TMP_Text text;
    private Vector3 motion;
    private float lastShown;
    private float duration;

    private void Show()
    {
        isActive = true;
        lastShown = Time.time;
        gameObject.SetActive(isActive);
    }

    private void Hide()
    {
        isActive = false;
        gameObject.SetActive(isActive);
    }

    void UpdateFloatingText()
    {
        if (!isActive) return;

        if (Time.time - lastShown > duration) Hide();

        gameObject.transform.position += motion * Time.deltaTime;
    }
}
