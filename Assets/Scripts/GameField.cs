using UnityEngine;

public class GameField : MonoBehaviour
{
    public Transform FirstCellPoint;
    public Vector2 CellSize;
    public int CellsCount = 100;
    public int CellsInRow = 10;

    private Vector2[] _cellsPositions;

    public void FillCellsPositions()
    {
        _cellsPositions = new Vector2[CellsCount];

        bool right = true;
        
        _cellsPositions[0] = FirstCellPoint.position;
        for (int i = 1; i < _cellsPositions.Length; i++)
        {
            bool needUp = i % CellsInRow == 0;
            if (needUp)
            {
                right = !right;
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * CellSize.y;
            }
            else
            {
                float xSign = right ? 1 : -1;
                float deltaX = xSign * CellSize.x;
                _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;
            }
        }
    }
}
