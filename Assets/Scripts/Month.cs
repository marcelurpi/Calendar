using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Month : MonoBehaviour
{
    [SerializeField] private int days = 0;
    [SerializeField] private int offset = 0;
    [SerializeField] private Cell[] cells = null;

    private void Start()
    {
        GenerateDays();
    }

    private void OnValidate()
    {
        GenerateDays();
    }

    public Cell GetCellFromDay(int day)
    {
        return cells[day - 1 + offset];
    }

    [Button("Get Children Cells", ButtonMode.ActiveAlways)]
    private void GetChildrenCells()
    {
        List<Cell> childrenCells = new List<Cell>();
        foreach(Transform row in transform)
        {
            foreach (Transform cell in row)
            {
                childrenCells.Add(cell.GetComponent<Cell>());
            }
        }
        cells = childrenCells.ToArray();
    }

    [Button("Generate Days", ButtonMode.ActiveAlways)]
    private void GenerateDays()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (i < (days + offset) && i >= offset)
            {
                cells[i].SetDay(i + 1 - offset);
                cells[i].SetDisabled(false);
            }
            else cells[i].SetDisabled(true);
        }
    }
}
