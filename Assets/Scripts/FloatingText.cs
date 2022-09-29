using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText
{
    public bool isActive;
    public GameObject gameObject;
    public TMP_Text text;
    public Vector3 motion;
    public float lastShown;
    public float duration;

    public string Text
    {
        get => text.text;
        set { text.text = value; }
    }

    public void Show()
    {
        isActive = true;
        lastShown = Time.time;
        gameObject.SetActive(isActive);
    }

    public void Hide()
    {
        isActive = false;
        gameObject.SetActive(isActive);
    }

    public void UpdateFloatingText()
    {
        if (!isActive) return;

        if (Time.time - lastShown > duration) Hide();

        gameObject.transform.position += motion * Time.deltaTime;
    }
}
