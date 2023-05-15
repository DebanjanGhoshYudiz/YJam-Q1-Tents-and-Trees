using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    public List<Cell> cellList = new List<Cell>();

    public List<int> rowTextList = new List<int>();
    public List<int> columnTextList = new List<int>();

    public Cell[,] cellArray = new Cell[5, 5];

    int colsCount, rowCount;
    int columnNo, rowNo;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadDataInArray();   
    }

    //Loading Data in array
    public void LoadDataInArray()
    {
        int index = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                cellArray[x, y] = cellList[index];
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
    public void FindClickedCellNeighbourStates(Cell cell)
    {
        Cell clickedCell = cell.neighbourCellList.Find((x) => x.currentState == CellStates.Tent);
        if(clickedCell != null)
        {
            Debug.Log("Cant Place Tent");
        }
        else
        {
            Debug.Log("Can Place Tent");
        }

        //Horizontal and vertical checking if neaby tree of clicked cell
        if(cellArray[cell.row-1, cell.column].currentState == CellStates.Tree || cellArray[cell.row+1, cell.column].currentState == CellStates.Tree || cellArray[cell.row, cell.column-1].currentState == CellStates.Tree || cellArray[cell.row , cell.column +1].currentState == CellStates.Tree)
        {
            Debug.Log("Tent is Placed Near Tree");
        }
        else
        { Debug.Log("Please Place Tent Near Tree on hoizontal or vertical to it"); }
    }

    public void AxisTentCount(Cell cell)
    {        
        colsCount = 0;
        rowCount = 0;

        columnNo = columnTextList[cell.column];
        rowNo = rowTextList[cell.row];

        Debug.Log("The Column Text is : " + columnNo);
        Debug.Log("The Row Text is : " + rowNo);

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
        Debug.Log("final Cols Count" + colsCount);
        Debug.Log("final Rows Count" + rowCount);
        if (colsCount == columnNo)
        {
            Debug.Log("Tent Perfect in Column");
        }
        else
        {
            Debug.Log("Error in Column Placement");
        }
        if (rowCount == rowNo)
        { Debug.Log("Tent Perfect in Row"); }
        else
        { Debug.Log("Error in Row Placement"); }
    }
}
