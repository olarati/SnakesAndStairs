using UnityEngine;

public class PlayersChipsCreator : MonoBehaviour
{
    public int PlayersCount = 2;
    public PlayerChip PlayerChipPrefab;
    public Sprite[] PlayerChipSprites = new Sprite[0];

    private void Start()
    {
        SpawnPlayersChips(PlayersCount);
    }

    private void SpawnPlayersChips(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if(i >= PlayerChipSprites.Length)
            {
                return;
            }
            SpawnPlayerChip(PlayerChipSprites[i]);
        }
    }

    private void SpawnPlayerChip(Sprite sprite)
    {
        if (!sprite)
        {
            return;
        }
        PlayerChip newPlayerChip = Instantiate(PlayerChipPrefab, transform.position, transform.rotation);
        newPlayerChip.SetSprite(sprite);
    }


}
