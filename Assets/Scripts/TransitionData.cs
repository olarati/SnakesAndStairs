using UnityEngine;

public class TransitionData : MonoBehaviour
{
    public int[] CellsStartIds;
    public int[] CellsEndIds;

    public int GetTransitionResultCellId(int cellId)
    {
        for (int i = 0; i < CellsStartIds.Length; i++)
        {
            if (CellsStartIds[i] == cellId)
            {
                return CellsEndIds[i];
            }
        }
        return -1;
    }

}
