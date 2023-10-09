using UnityEngine;

public class PlayersChipsCreator : MonoBehaviour
{
    public PlayerChip PlayerChipPrefab;
    public Sprite[] PlayerChipSprites = new Sprite[0];

    private PlayerChip[] playersChips;

    public PlayerChip[] SpawnPlayersChips(int count)
    {
        playersChips = new PlayerChip[count];
        for (int i = 0; i < count; i++)
        {
            if(i >= PlayerChipSprites.Length)
            {
                break;
            }
            playersChips[i] = SpawnPlayerChip(PlayerChipSprites[i]);
        }
        return playersChips;
    }

    public void Clear()
    {
        DestroyPlayersChips();
    }

    private PlayerChip SpawnPlayerChip(Sprite sprite)
    {
        if (!sprite)
        {
            return null;
        }
        PlayerChip newPlayerChip = Instantiate(PlayerChipPrefab, transform.position, transform.rotation);
        newPlayerChip.SetSprite(sprite);
        return newPlayerChip;
    }

    private void DestroyPlayersChips()
    {
        for (int i = 0; i < playersChips.Length; i++)
        {
            Destroy(playersChips[i].gameObject);
        }
    }

}
