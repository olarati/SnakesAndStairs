using UnityEngine;

public class CubeThrowAnimator : MonoBehaviour
{
    public Animation CubeAnimation;
    public GameCubeThrower GameCubeThrower;

    public void PlayAnimation()
    {
        CubeAnimation.Play();
    }

    // Вызывается из анимации
    public void OnAnimationEnd()
    {
        GameCubeThrower.ContinueAfterCubeAnimation();
    }
}
