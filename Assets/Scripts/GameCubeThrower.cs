using UnityEngine;

public class GameCubeThrower : MonoBehaviour
{
    public GameStateChanger GameStateChanger;

    public GameCube GameCubePrefab;
    public Transform GameCubePoint;

    private GameCube _gameCube;

    public void ThrowCube()
    {
        int cubeValue = _gameCube.ThrowCube();
        GameStateChanger.DoPlayerTurn(cubeValue);
    }

    private void Start()
    {
        CreateGameCube();
    }

    private void CreateGameCube()
    {
        _gameCube = Instantiate(GameCubePrefab, GameCubePoint.position, GameCubePoint.rotation);
        _gameCube.HideCube();
    }

}
