using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    public PlayersChipsAnimator PlayersChipsAnimator;
    public CubeThrowAnimator CubeThrowAnimator;
    public GameStateChanger GameStateChanger;
    public GameCubeThrower GameCubeThrower;

    public float NewCellMoveDuration = 0.01f;

    private float _oldCellMoveDuration;
    private AnimationClip _oldCubeThrowAnimationClip;

    private bool _isActive;

    [ContextMenu("StartAutoPlay")]
    private void StartAutoPlay()
    {
        _oldCellMoveDuration = PlayersChipsAnimator.CellMoveDuration;
        _oldCubeThrowAnimationClip = CubeThrowAnimator.CubeAnimation.clip;

        PlayersChipsAnimator.CellMoveDuration = NewCellMoveDuration;
        CubeThrowAnimator.CubeAnimation.clip = null;

        _isActive = true;
    }

    [ContextMenu("StopAutoPlay")]
    private void StopAutoPlay()
    {
        PlayersChipsAnimator.CellMoveDuration = _oldCellMoveDuration;
        CubeThrowAnimator.CubeAnimation.clip = _oldCubeThrowAnimationClip;

        _isActive = false;
    }

    private void Update()
    {
        DoAutoPlay();
    }

    private void DoAutoPlay()
    {
        if (!_isActive)
        {
            return;
        }

        if(!GameStateChanger.ThrowButton.interactable)
        {
            return;
        }
        GameCubeThrower.ThrowCube();
        CubeThrowAnimator.OnAnimationEnd();
    }
}
