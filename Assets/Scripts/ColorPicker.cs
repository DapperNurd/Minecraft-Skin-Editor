using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Color color;

    [SerializeField] Image colorPreview;
    [SerializeField] TMP_Text colorHex;

    [SerializeField] Slider rSlider;
    [SerializeField] Slider gSlider;
    [SerializeField] Slider bSlider;

    [SerializeField] TMP_Text rLabel;
    [SerializeField] TMP_Text gLabel;
    [SerializeField] TMP_Text bLabel;

    // Start is called before the first frame update
    void Start()
    {
        UpdateColorValue();
    }

    public void UpdateColorValue() {
        color = new Color(rSlider.value/255f, gSlider.value/255f, bSlider.value/255f);
        colorHex.text = ColorUtility.ToHtmlStringRGB(color);
        colorPreview.color = color;

        rLabel.text = rSlider.value.ToString();
        gLabel.text = gSlider.value.ToString();
        bLabel.text = bSlider.value.ToString();
    }
}
