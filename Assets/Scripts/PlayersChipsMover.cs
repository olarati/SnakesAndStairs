using UnityEngine;

public class PlayersChipsMover : MonoBehaviour
{
    public GameField GameField;
    public TransitionSettings TransitionSettings;

    private PlayerChip[] _playersChips;
    private int[] _playersChipsCellsIds;

    public void StartGame(PlayerChip[] playersChips)
    {
        _playersChips = playersChips;
        _playersChipsCellsIds = new int[playersChips.Length];
        RefreshChipsPositions();
    }

    public void RefreshChipsPositions()
    {
        for (int i = 0; i < _playersChips.Length; i++)
        {
            RefreshChipPosition(i);
        }
    }

    public void MoveChip(int playerId, int steps)
    {
        _playersChipsCellsIds[playerId] += steps;
        if(_playersChipsCellsIds[playerId] >= GameField.CellsCount)
        {
            _playersChipsCellsIds[playerId] = GameField.CellsCount - 1;
        }
        TryApplyTransition(playerId);
        RefreshChipPosition(playerId);
    }

    public bool CheckPlayerFinished(int playerId)
    {
        return _playersChipsCellsIds[playerId] >= GameField.CellsCount - 1;
    }

    private void RefreshChipPosition(int playerId)
    {
        Vector2 chipPosition = GameField.GetCellPosition(_playersChipsCellsIds[playerId]);
        _playersChips[playerId].SetPosition(chipPosition);
    }

    private void TryApplyTransition(int playerId)
    {
        int resultCellId = TransitionSettings.GetTransitionResultCellId(_playersChipsCellsIds[playerId]);
        if(resultCellId < 0)
        {
            return;
        }

        _playersChipsCellsIds[playerId] = resultCellId;
    }
    
}

