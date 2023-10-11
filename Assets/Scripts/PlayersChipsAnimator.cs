using UnityEngine;
using DG.Tweening;
using System;

public class PlayersChipsAnimator : MonoBehaviour
{
    public GameField GameField;

    public float CellMoveDuration = 0.35f;

    public void AnimateChipMovement(PlayerChip playerChip, int[] movememntCells, Action onMovementEnd)
    {
        Sequence movememntSeq = DOTween.Sequence();
        for (int i = 0; i < movememntCells.Length; i++)
        {
            Vector3 endPosition = GameField.GetCellPosition(movememntCells[i]);
            movememntSeq.Append(playerChip.transform.DOMove(endPosition, CellMoveDuration));
        }
        movememntSeq.OnComplete(() => onMovementEnd.Invoke()); 
    }
}
