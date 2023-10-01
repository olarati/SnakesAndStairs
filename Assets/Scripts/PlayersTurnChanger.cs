using UnityEngine;

public class PlayersTurnChanger : MonoBehaviour
{
    private PlayerChip[] _playersChips;

    private int _currentPlayerId = -1;

    public void StartGame(PlayerChip[] playersChips)
    {
        _playersChips = playersChips;
        MovePlayerTurn();
    }

    private void MovePlayerTurn()
    {
        _currentPlayerId++;
        if(_currentPlayerId >= _playersChips.Length)
        {
            _currentPlayerId = 0;
        }
        StartPlayerTurn(_currentPlayerId);
    }

    private void StartPlayerTurn(int playerId)
    {

    }

}
