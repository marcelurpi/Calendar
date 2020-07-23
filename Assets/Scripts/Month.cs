using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month : MonoBehaviour
{
    [SerializeField] private int days = 0;
    [SerializeField] private Cell[] cells = null;

    [ContextMenu("GetChildrenCells")]
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

    [ContextMenu("Generate Days")]
    private void GenerateDays()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if(i < days) cells[i].SetDay(i + 1);
            else cells[i].SetDisabled(false);
        }
    }
}
