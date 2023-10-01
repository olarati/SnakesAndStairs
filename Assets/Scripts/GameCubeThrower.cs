using UnityEngine;
using UnityEngine.UI;

public class GameCubeThrower : MonoBehaviour
{
    public GameCube GameCubePrefab;
    public Transform GameCubePoint;

    public Button ThrowButton;

    private GameCube _gameCube;

    [ContextMenu("ThrowCube")]
    public void ThrowCube()
    {
        _gameCube.ThrowCube();
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
