using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    public int PlayersCount = 2;

    public PlayersChipsCreator PlayersChipsCreator;
    public PlayersTurnChanger PlayersTurnChanger;
    public PlayersChipsMover PlayersChipsMover;
    public GameField GameField; 

    public void DoPlayerTurn(int steps)
    {
        int currentPlayerId = PlayersTurnChanger.GetCurrentPlayerId();
        PlayersChipsMover.MoveChip(currentPlayerId, steps);
        PlayersTurnChanger.MovePlayerTurn();
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameField.FillCellsPositions();
        PlayerChip[] playersChips = PlayersChipsCreator.SpawnPlayersChips(PlayersCount);
        PlayersTurnChanger.StartGame(playersChips);
        PlayersChipsMover.StartGame(playersChips);
    }

}
