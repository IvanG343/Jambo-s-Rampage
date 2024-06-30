using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Parallax params")]
    [SerializeField] private float parallaxEffectX;
    [SerializeField] private float parallaxEffectY;
    private Vector2 startPos;
    private Vector2 length;

    [Header("References")]
    [SerializeField] GameObject cam;

    private void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
        length = new Vector2(GetComponent<SpriteRenderer>().bounds.size.x, GetComponent<SpriteRenderer>().bounds.size.y);
    }

    private void Update()
    {
        float distanceX = cam.transform.position.x * parallaxEffectX;
        float distanceY = cam.transform.position.y * parallaxEffectY;
        float movementX = cam.transform.position.x * (1 - parallaxEffectX);
        float movementY = cam.transform.position.y * (1 - parallaxEffectY);

        transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, transform.position.z);

        if (movementX > startPos.x + length.x) startPos.x += length.x;
        else if (movementX < startPos.x - length.x) startPos.x -= length.x;

        if (movementY > startPos.y + length.y) startPos.y += length.y;
        else if (movementY < startPos.y - length.y) startPos.y -= length.y;
    }
}