using UnityEngine;
using TMPro;

public class PlayersTurnChanger : MonoBehaviour
{
    public TextMeshProUGUI PlayerText;

    private PlayerChip[] _playersChips;

    private int _currentPlayerId;

    public void StartGame(PlayerChip[] playersChips)
    {
        _playersChips = playersChips;
        _currentPlayerId = -1;
        MovePlayerTurn();
    }

    public int GetCurrentPlayerId()
    {
        return _currentPlayerId;
    }

    public void MovePlayerTurn()
    {
        _currentPlayerId++;
        if(_currentPlayerId >= _playersChips.Length)
        {
            _currentPlayerId = 0;
        }
        SetPlayerText(_currentPlayerId);
    }

    private void SetPlayerText(int playerId)
    {
        PlayerText.text = $"Игрок {playerId + 1}";
    }
}
