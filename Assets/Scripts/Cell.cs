using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color disabledImageColor = Color.white;
    [SerializeField] private TextMeshProUGUI dayText = null;
    [SerializeField] private Image image = null;

    private Color baseImageColor = Color.white;

    private void Start()
    {
        baseImageColor = image.color;
    }

    public void SetDay(int day)
    {
        dayText.text = day.ToString();
    }

    public void SetDisabled(bool disabled)
    {
        image.color = disabled ? disabledImageColor : baseImageColor;
    }
}
