using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerDownHandler
{
    public List<Cell> neighbourCellList = new List<Cell>();
    public Image cellImage;
    public Sprite dirt;
    public Sprite grass;
    public Sprite tent;

    public Level currentLevel;

    public CellStates currentState;       

    public int row;
    public int column;
    public bool isValid;

    private int numberOfCellStates = Enum.GetValues(typeof(CellStates)).Length-1;
    private int x, y;

    private void Start()
    {
        currentLevel = LevelManager.instance.currentLevels;
        if(currentState == CellStates.Tree)
        {
            isValid = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //To do nothing to the tree state
        if (currentState != CellStates.Tree)
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
                cellImage.sprite = grass;
                isValid = true;
                break;

            case CellStates.Tent:                
                cellImage.sprite = tent;
                currentLevel.CheckRules(this);
                break;

            case CellStates.Default:                       
                cellImage.sprite = dirt;
                isValid = false;
                break;

            case CellStates.Tree:
                currentState = CellStates.Tree;
                Debug.Log("Current Row " + row + "Current Column " + column + "Current State " + currentState);
                break;

            default:
                break;
        }
    }


    //Find Neighbour of every individual cells and store in a list
    public void CellNeighbourFinder()
    {
        Cell[,] cellArray = LevelManager.instance.currentLevels.cellArray;

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
