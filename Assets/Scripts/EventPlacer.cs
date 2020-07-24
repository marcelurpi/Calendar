using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlacer : MonoBehaviour
{
    [SerializeField] private int day = 0;
    [SerializeField] private string eventToPlace = null;
    [SerializeField] private Month month = null;

    [ContextMenu("Place Event")]
    private void PlaceEvent()
    {
        Cell dayCell = month.GetCellFromDay(day);
        dayCell.SetContent(eventToPlace);
    }
}
