using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform),typeof(GridLayoutGroup))]
public class Grid : MonoBehaviour
{
    [SerializeField] private int _row;
    [SerializeField] private int _column;
    [SerializeField] private GameObject _cellPF;

    private RectTransform _rectTransform;
    private GridLayoutGroup _gridLayOut;

    [SerializeField]private int _spacing;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _gridLayOut = GetComponent<GridLayoutGroup>();
    }
    void Start()
    {
        CreateGrid( _row,_column,_spacing);
    }

    // Update is called once per frame
    public void CreateGrid(int row, int column,float spacing)
    {
        _gridLayOut.spacing = new Vector2(spacing, spacing);
        float totalhorizontalspace = _rectTransform.rect.width - (spacing * (column-1)) ;
        float totalverticalspace = _rectTransform.rect.height - (spacing * (row -1 )) ;
        _gridLayOut.cellSize = new Vector2 (CellWidth(column,totalhorizontalspace), CellHeight(row,totalverticalspace));
         int numberofcells = NumberOfCells(column, row);
        CreateCell(numberofcells);
    }

    private void CreateCell(int numberofcells)
    {
        for(int i =1;i<= numberofcells;i++)
        {
            GameObject cell = Instantiate(_cellPF);
            cell.GetComponent<RectTransform>().SetParent(_rectTransform, false);
        }
       
    }

    private float CellWidth(int row,float width)
    {
        return width/row;
    }
    private float CellHeight(int column,float height)
    {
        return height / column;
    }
    private int NumberOfCells(int row,int column)
    {
        return row * column;
    }

    
}
