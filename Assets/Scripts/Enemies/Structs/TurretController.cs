using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Sprites for each direction")]
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite upLeftSprite;
    [SerializeField] private Sprite upRightSprite;
    [SerializeField] private Sprite downLeftSprite;
    [SerializeField] private Sprite downRightSprite;

    [Header("Fire points")]
    [SerializeField] private Transform upFirePoint;
    [SerializeField] private Transform downFirePoint;
    [SerializeField] private Transform leftFirePoint;
    [SerializeField] private Transform rightFirePoint;
    [SerializeField] private Transform upLeftFirePoint;
    [SerializeField] private Transform upRightFirePoint;
    [SerializeField] private Transform downLeftFirePoint;
    [SerializeField] private Transform downRightFirePoint;

    [Header("Fire params")]
    [SerializeField] private GameObject turretBullet;
    [SerializeField] private float fireForce;
    [SerializeField] private float fireRate;
    private Transform firePoint;
    private Vector2 shootDirection;
    private float nextFireTime;

    [Header("References")]
    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private Camera mainCamera;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Hero").GetComponent<Transform>();
        mainCamera = Camera.main;
        nextFireTime = 0f;
    }

    private void Update()
    {
        Vector2 directionToPlayer = GetDirectionToPlayer();
        SetSpriteAndFirePoint(directionToPlayer);

        if(Time.time >= nextFireTime && IsInView())
        {
            Shoot(shootDirection);
            nextFireTime = Time.time + fireRate;
        }
    }

    private bool IsInView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    private Vector2 GetDirectionToPlayer()
    {
        Vector2 direction = playerTransform.position - transform.position;
        direction.Normalize();
        return direction;
    }

    private void SetSpriteAndFirePoint(Vector2 _directionToPlayer)
    {
        float angle = Mathf.Atan2(_directionToPlayer.x, _directionToPlayer.y) * Mathf.Rad2Deg;

        if(angle > -22.5f && angle <= 22.5f)
        {
            spriteRenderer.sprite = upSprite;
            firePoint = upFirePoint;
            shootDirection = Vector2.up;
        }
        else if(angle > 22.5f && angle <= 67.5f)
        {
            spriteRenderer.sprite = upRightSprite;
            firePoint = upRightFirePoint;
            shootDirection = new Vector2(1, 1);
        }
        else if(angle > 67.5f && angle <= 112.5f)
        {
            spriteRenderer.sprite = rightSprite;
            firePoint = rightFirePoint;
            shootDirection = Vector2.right;
        }
        else if(angle > 112.5f && angle <= 157.5f)
        {
            spriteRenderer.sprite = downRightSprite;
            firePoint = downRightFirePoint;
            shootDirection = new Vector2(1, -1);
        }
        else if((angle > 157.5f && angle <= 180) || (angle > -180 && angle <= -157.5f))
        {
            spriteRenderer.sprite = downSprite;
            firePoint = downFirePoint;
            shootDirection = Vector2.down;
        }
        else if(angle > -157.5f && angle <= -112.5f)
        {
            spriteRenderer.sprite = downLeftSprite;
            firePoint = downLeftFirePoint;
            shootDirection = new Vector2(-1, -1);
        }
        else if(angle > -112.5f && angle <= -67.5f)
        {
            spriteRenderer.sprite = leftSprite;
            firePoint = leftFirePoint;
            shootDirection = Vector2.left;
        }
        else if(angle > -67.5f && angle <= -22.5f)
        {
            spriteRenderer.sprite = upLeftSprite;
            firePoint = upLeftFirePoint;
            shootDirection = new Vector2(-1, 1);
        }
    }

    private void Shoot(Vector2 _shootDirection)
    {
        GameObject bullet = Instantiate(turretBullet, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = _shootDirection * fireForce;
    }
}
