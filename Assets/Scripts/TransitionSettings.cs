using UnityEngine;

public class TransitionSettings : MonoBehaviour
{
    public TransitionData[] TransitionDatas = new TransitionData[0];

    public int GetTransitionResultCellId(int startCellId)
    {
        for (int i = 0; i < TransitionDatas.Length; i++)
        {
            int resultCellId = TransitionDatas[i].GetTransitionResultCellId(startCellId);
            if (resultCellId >= 0)
            {
                return resultCellId;
            }
        }
        
        return -1;
    }
}
