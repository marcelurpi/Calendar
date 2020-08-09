using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color disabledImageColor = Color.white;
    [SerializeField] private TextMeshProUGUI contentText = null;
    [SerializeField] private TextMeshProUGUI dayText = null;
    [SerializeField] private Image image = null;
    [SerializeField] private Button cellButton = null;
    [SerializeField] private EventPlacer eventPlacer = null;

    private int day = 0;
    private Color baseImageColor = Color.white;

    private void Start()
    {
        baseImageColor = image.color;

        cellButton.onClick.AddListener(CellClicked);
    }

    private void CellClicked()
    {
        if(Slot.slotSelected != null)
        {
            eventPlacer.PlaceEvent(day, Slot.slotSelected.GetEventHeld());
            Slot.slotSelected = null;
        }
    }

    public void SetDay(int day)
    {
        this.day = day;
        dayText.text = day.ToString();
    }

    public void SetDisabled(bool disabled)
    {
        image.color = disabled ? disabledImageColor : baseImageColor;
        dayText.gameObject.SetActive(!disabled);
    }

    public void SetContent(string content)
    {
        contentText.text = content;
    }
}
