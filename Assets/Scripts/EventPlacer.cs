using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlacer : MonoBehaviour
{
    [SerializeField] private int day = 0;
    [SerializeField] private EventData eventToPlace = null;
    [SerializeField] private Month month = null;

    [Button("Place Event", ButtonMode.ActiveOnPlayMode)]
    public void PlaceEvent()
    {
        Cell dayCell = month.GetCellFromDay(day);
        dayCell.SetContent(eventToPlace.GetName());
    }
}
