using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerDownHandler
{
    public List<Cell> neighbourCellList = new List<Cell>();
    public Image cellImage;
    public Sprite tent;
    public CellStates currentState;       

    public int row;
    public int column;   

    private int numberOfCellStates = Enum.GetValues(typeof(CellStates)).Length-1;
    private int x, y;
        
    public void OnPointerDown(PointerEventData eventData)
    {
        int currentIndex = (int)currentState;
        currentIndex++;
        if (currentIndex == numberOfCellStates)
        {
            currentIndex = 0;
        }            
        currentState = (CellStates)currentIndex;
        OnChangeCellState(currentState);
    }

    public void setData(int rows, int columns)
    {
        x = rows;
        y = columns;
        CellNeighbourFinder();             
    }

    public void OnChangeCellState(CellStates cellStates)
    {            
        switch (cellStates)
        {
            case CellStates.Grass:
                cellImage.color = new Color32(136, 255, 78, 255);                
                break;

            case CellStates.Tent:
                cellImage.color = new Color32(255, 255, 255, 255);
                cellImage.sprite = tent;
                GridManager.instance.FindClickedCellNeighbourStates(this);

                GridManager.instance.AxisTentCount(this);
                break;

            case CellStates.Default:
                cellImage.sprite = null;
                cellImage.color = new Color32(255, 255, 255, 255);                
                break;

            case CellStates.Tree:                
                Debug.Log("Current Row " + row + "Current Column " + column + "Current State " + currentState);
                break;

            default:
                break;
        }
    }


    //Find Neighbour of every individual cells and store in a list
    public void CellNeighbourFinder()
    {
        Cell[,] cellArray = GridManager.instance.cellArray;

        for (int x = Mathf.Max(0, row - 1); x <= Mathf.Min(row + 1, 4); x++)
        {
            for (int y = Mathf.Max(0, column - 1); y <= Mathf.Min(column + 1, 4); y++)
            {
                if (x != row || y != column)
                {
                    neighbourCellList.Add(cellArray[x, y]);
                }
            }
        }
    }
}    
