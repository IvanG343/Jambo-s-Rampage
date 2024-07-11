using UnityEngine;

public class EnemyStructHealth : Health
{
    [Header("Visual params")]
    [SerializeField] private Sprite brokenSprite;

    [Header("SFX")]
    [SerializeField] private AudioClip explosionSound;

    [Header("References")]
    [SerializeField] private GameObject explosion;

    protected override void OnDeath()
    {
        foreach (Behaviour component in componentsToDisable)
            component.enabled = false;

        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        ChangeSpriteToBroken();

        SoundManager.instance.PlaySound(explosionSound);
        GameManager.instance.AddScorePoints(maxHealth * 100);
    }

    private void ChangeSpriteToBroken()
    {
        if(spriteRenderer != null && brokenSprite != null)
            spriteRenderer.sprite = brokenSprite;
    }
}
