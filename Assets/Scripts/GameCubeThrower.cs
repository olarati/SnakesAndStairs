using UnityEngine;

public class GameCubeThrower : MonoBehaviour
{
    public GameStateChanger GameStateChanger;

    public GameCube GameCubePrefab;
    public Transform GameCubePoint;
    public CubeThrowAnimator CubeThrowAnimator;

    private GameCube _gameCube;
    private int _cubeValue;

    public void ThrowCube()
    {
        _cubeValue = _gameCube.ThrowCube();
        CubeThrowAnimator.PlayAnimation();
    }

    public void ContinueAfterCubeAnimation()
    {
        GameStateChanger.DoPlayerTurn(_cubeValue);
    }

    private void Start()
    {
        CreateGameCube();
    }

    private void CreateGameCube()
    {
        _gameCube = Instantiate(GameCubePrefab, GameCubePoint.position, GameCubePoint.rotation, GameCubePoint);
        _gameCube.HideCube();
    }

}
