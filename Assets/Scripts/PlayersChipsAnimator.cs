using UnityEngine;

public class PlayersChipsAnimator : MonoBehaviour
{
    public GameStateChanger GameStateChanger;
    public GameField GameField;

    public float CellMoveDuration = 0.3f;

    private PlayerChip _playerChip;
    private bool isAnimateNow;
    private int[] _movementCells;
    private int _currentCellId;
    private float _cellMoveTimer;
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    public void AnimateChipMovement(PlayerChip playerChip, int[] movementCells)
    {
        _playerChip = playerChip;
        _movementCells = movementCells;
        isAnimateNow = true;
        _currentCellId = -1;

        ToNextCell();
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

        _playerChip.SetPosition(Vector2.Lerp(_startPosition, _endPosition, _cellMoveTimer));
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
        GameStateChanger.ContinueGameAfterChipAnimation();
    }
}
