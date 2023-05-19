using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Cell> levelCellList = new List<Cell>();
    public List<int> levelRowTextList = new List<int>();
    public List<int> levelColumnTextList = new List<int>();


    public Cell[,] cellArray = new Cell[5, 5];

    int colsCount, rowCount;
    int columnNo, rowNo;

    public int gridLevel;
    
    private void Start()
    {
        LoadDataInArray();
        gridLevel = 5;
    }

    //Loading Data in array
    public void LoadDataInArray()
    {
        int index = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                cellArray[x, y] = levelCellList[index];
                index++;
            }
        }
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                cellArray[x, y].setData(x, y);
                index++;
            }
        }
    }    

    //Finding Neighbour of particular click cell
    public bool FindClickedCellNeighbourStates(Cell cell)
    {
        bool isTentNearby;
        Cell clickedCell = cell.neighbourCellList.Find((x) => x.currentState == CellStates.Tent);
        if (clickedCell != null)
        {
            isTentNearby = false;
        }
        else
        {
            isTentNearby = true;
            Debug.Log("Can Place Tent");
        }
        return isTentNearby;
    }

    public bool ColumnTentCount(Cell cell)
    {
        bool isEqualsCount;
        colsCount = 0;
        columnNo = levelColumnTextList[cell.column];
        Debug.Log("The Column Text is : " + columnNo);

        //Column Check
        for (int x = 0; x < 5; x++)
        {
            for (int y = cell.column; y <= cell.column; y++)
            {
                if (cellArray[x, y].currentState == CellStates.Tent)
                {
                    colsCount += 1;
                }
            }
        }
        Debug.Log("final Cols Count" + colsCount);
        if (colsCount <= columnNo)
        {
            Debug.Log("Tent Perfect in Column");
            isEqualsCount = true;
        }
        else
        {
            isEqualsCount = false;
        }
        return isEqualsCount;
    }

    public bool RowTentCount(Cell cell)
    {
        bool isEqualsCount;
        rowCount = 0;
        rowNo = levelRowTextList[cell.row];

        Debug.Log("The Row Text is : " + rowNo);

        //Row Check
        for (int i = cell.row; i <= cell.row; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (cellArray[i, j].currentState == CellStates.Tent)
                {
                    rowCount += 1;
                }
            }
        }
        Debug.Log("final Rows Count" + rowCount);
        if (rowCount <= rowNo)
        {
            Debug.Log("Tent Perfect in Row");
            isEqualsCount = true;
        }        
        else
        {
            isEqualsCount = false;
        }

        return isEqualsCount;
    }

    //Checks if there is tree nearby near the clicked cell
    public bool IsNearbyTree(Cell cell)
    {
        bool checkCells = false;

        if (cell.row - 1 >= 0)
        {
            Debug.Log(cell.column);
            Debug.Log(cell.currentState);
            Debug.Log(cellArray[cell.row - 1, cell.column].currentState);
            checkCells = checkCells || cellArray[cell.row - 1, cell.column].currentState == CellStates.Tree;
            Debug.Log("First Time " + checkCells);
        }
        if (cell.row + 1 <= 4)
        {
            checkCells = checkCells || cellArray[cell.row + 1, cell.column].currentState == CellStates.Tree;
            Debug.Log("Second Time " + checkCells);
        }
        if (cell.column - 1 >= 0)
        {
            checkCells = checkCells || cellArray[cell.row, cell.column - 1].currentState == CellStates.Tree;
            Debug.Log("Third Time " + checkCells);
        }
        if (cell.column + 1 <= 4)
        {
            checkCells = checkCells || cellArray[cell.row, cell.column + 1].currentState == CellStates.Tree;
            Debug.Log("Fourth Time " + checkCells);
        }
        return checkCells;
    }

    public void LevelComplete()
    {
        //checking every Column count
        if(levelCellList.Find(x => x.isValid == true))
        {
            if(levelCellList.FindAll(x => x.currentState == CellStates.Tent).Count == gridLevel)
            {
                Debug.Log("Level Completed");
                UIManager.iManager.ShowNextScreen(CanvasStates.LevelComplete);
            }
        }
    }

    public void CheckRules(Cell cell)
    {
        if (!IsNearbyTree(cell))
        {
            //RuleBreak HighPriority
            Debug.Log("Rule 3 Break, Kindly Fix the rule");
            RuleManager.instance.RuleBroke(Rules.Rule3);
        }
        else if (!FindClickedCellNeighbourStates(cell))
        {
            //RuleBreak
            Debug.Log("Rule 2 Break, Kindly Fix the rule");
            RuleManager.instance.RuleBroke(Rules.Rule2);
        }
        else if (!RowTentCount(cell))
        {
            //RulesBreak
            Debug.Log("Rule 1 Break, Row Count incorrect");
            RuleManager.instance.RuleBroke(Rules.Rule1);
        }
        else if (!ColumnTentCount(cell))
        {
            //Rule Break
            Debug.Log("Rule 1 Break, Column Count incorrect");
            RuleManager.instance.RuleBroke(Rules.Rule1);
        }
        else
        {
            //follows all rule
            cell.isValid = true;
            LevelComplete();
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
