using UnityEngine;

public class CubeThrowAnimator : MonoBehaviour
{
    public Animation CubeAnimation;
    public GameCubeThrower GameCubeThrower;

    public void PlayAnimation()
    {
        CubeAnimation.Play();
    }

    // ���������� �� ��������
    public void OnAnimationEnd()
    {
        GameCubeThrower.ContinueAfterCubeAnimation();
    }
}
