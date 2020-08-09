using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public static Slot slotSelected = null;

    [SerializeField] private EventData eventHeld = null;
    [SerializeField] private TextMeshProUGUI contentText = null;
    [SerializeField] private Button slotButton = null;

    public EventData GetEventHeld() => eventHeld;

    private void Start()
    {
        UpdateContents();

        slotButton.onClick.AddListener(SlotClicked);
    }

    private void OnValidate()
    {
        UpdateContents();
    }

    private void SlotClicked()
    {
        if(slotSelected == this)
        {
            slotSelected = null;
        }
        else
        {
            slotSelected = this;
        }
    }

    private void UpdateContents()
    {
        if(contentText != null && eventHeld != null)
        {
            contentText.text = eventHeld.GetName();
        }
    }
}
