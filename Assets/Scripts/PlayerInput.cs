using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [Header("Variables")]
    private float dirHor;
    private float dirVert;
    private bool jumpBtnPressed;

    [Header("References")]
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        dirHor = Input.GetAxisRaw("Horizontal");
        dirVert = Input.GetAxisRaw("Vertical");
        jumpBtnPressed = Input.GetButtonDown("Jump");

        playerMovement.Move(dirHor, dirVert, jumpBtnPressed);
    }
}
