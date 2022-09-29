using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject textContainer;
    
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }

    private void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.Text = message;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = color;
        floatingText.gameObject.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }
    private FloatingText GetFloatingText()
    {
        FloatingText text = floatingTexts.Find(text => !text.isActive);

        if (text == null)
        {
            text = new FloatingText();
            text.gameObject = Instantiate(textPrefab);
            text.gameObject.transform.SetParent(textContainer.transform);
            text.text = text.gameObject.GetComponent<TMP_Text>();
            
            floatingTexts.Add(text);
        }

        return text;
    }
}
