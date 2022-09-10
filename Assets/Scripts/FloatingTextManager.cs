using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject textContainer;
    
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.text.text = message;
        floatingText.text.color = color;
        floatingText.text.fontSize = fontSize;
        floatingText.gameObject.transform.position = position;
        floatingText.text = message;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
