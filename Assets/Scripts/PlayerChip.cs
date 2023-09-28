using UnityEngine;

public class PlayerChip : MonoBehaviour
{
    public void SetSprite(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    
}
