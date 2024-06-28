using UnityEngine;

public class EnemyStructHealth : Health
{
    [Header("Visual params")]
    [SerializeField] Sprite brokenSprite;
    private SpriteRenderer spriteRenderer;

    [Header("References")]
    [SerializeField] GameObject explosion;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        ChangeSpriteToBroken();
    }

    private void ChangeSpriteToBroken()
    {
        if(spriteRenderer != null && brokenSprite != null)
            spriteRenderer.sprite = brokenSprite;
    }
}
