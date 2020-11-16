using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNothingUpdate : MonoBehaviour
{
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }


    public void TextUpdate(float value)
    {
        if (value == 0f)
        {
            _text.text = @"Minimal
Nothing";
        }
        else if (value == 1f)
        {
            _text.text = @"Maximal
Nothing";
        }
        else
        {
            _text.text = $"Nothing: {Mathf.RoundToInt(value*100)}%";
        }
        Image img = GameObject.Find("PanelSettings").GetComponent<Image>();

        img.color = new Color(img.color.r, img.color.g, img.color.b, value);
    }
}
