using UnityEngine;

public class PlayersChipsAnimator : MonoBehaviour
{
    public GameField GameField;

    public float CellMoveDuration = 0.7f;

    private PlayerChip _playerChip;
    private bool isAnimateNow;
    private int[] _movementCells;
    private int _currentCellId;
    private float _cellMoveTimer;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    public void AnimateChipMovement(PlayerChip playerChip, int startCellId, int lastCellId, int afterTransitionCellId)
    {
        _playerChip = playerChip;
        _movementCells = GetMovementCells(startCellId, lastCellId, afterTransitionCellId);
        isAnimateNow = true;
        _currentCellId = -1;

        ToNextCell();
    }

    private int[] GetMovementCells(int startCellId, int lastCellId, int afterTransitionCellId)
    {
        int cellsCount = lastCellId - startCellId + 1;
        bool hasTransition = lastCellId != afterTransitionCellId;
        if (hasTransition)
        {
            cellsCount++;
        }
        int[] movementCells = new int[cellsCount];

        for (int i = 0; i < movementCells.Length; i++)
        {
            if (i == movementCells.Length - 1 && hasTransition)
            {
                movementCells[i] = afterTransitionCellId;
            }
            else
            {
                movementCells[i] = startCellId + i;
            }
        }
        return movementCells;
    }

    private void Update()
    {
        Animation();
    }

    private void Animation()
    {
        if (!isAnimateNow)
        {
            return;
        }

        if(_cellMoveTimer >= 1)
        {
            ToNextCell();
        }

        if (!isAnimateNow)
        {
            return;
        }

        _playerChip.SetPosition(Vector3.Lerp(_startPosition, _endPosition, _cellMoveTimer));
        _cellMoveTimer += Time.deltaTime / CellMoveDuration;

    }

    private void ToNextCell()
    {
        _currentCellId++;
        if(_currentCellId >= _movementCells.Length - 1)
        {
            EndAnimation();
            return;
        }

        _startPosition = GameField.GetCellPosition(_movementCells[_currentCellId]);
        _endPosition = GameField.GetCellPosition(_movementCells[_currentCellId + 1]);
        _cellMoveTimer = 0;
    }

    private void EndAnimation()
    {
        isAnimateNow = false;
    }
}
