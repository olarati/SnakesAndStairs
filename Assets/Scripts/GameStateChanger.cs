using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    public int PlayersCount = 2;

    public PlayersChipsCreator PlayersChipsCreator;
    public PlayersTurnChanger PlayersTurnChanger;
    public GameField GameField;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameField.FillCellsPositions();
        PlayerChip[] playersChips = PlayersChipsCreator.SpawnPlayersChips(PlayersCount);
        PlayersTurnChanger.StartGame(playersChips);
    }

}
