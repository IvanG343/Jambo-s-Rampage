using UnityEngine;

public class EnemyStructHealth : Health
{
    [Header("Visual params")]
    [SerializeField] private Sprite brokenSprite;

    [Header("References")]
    [SerializeField] private GameObject explosion;

    protected override void OnDeath()
    {
        foreach (Behaviour component in componentsToDisable)
            component.enabled = false;

        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        ChangeSpriteToBroken();
    }

    private void ChangeSpriteToBroken()
    {
        if(spriteRenderer != null && brokenSprite != null)
            spriteRenderer.sprite = brokenSprite;
    }
}
