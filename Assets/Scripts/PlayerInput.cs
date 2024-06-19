using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [Header("Variables")]
    private float dirHor;
    private float dirVert;
    private bool jumpBtnPressed;
    private bool shootBtnPressed;

    [Header("References")]
    private PlayerMovement playerMovement;
    private WeaponController weaponController;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        weaponController = GetComponentInChildren<WeaponController>();
    }

    private void Update()
    {
        dirHor = Input.GetAxisRaw("Horizontal");
        dirVert = Input.GetAxisRaw("Vertical");
        jumpBtnPressed = Input.GetButtonDown("Jump");
        playerMovement.Move(dirHor, dirVert, jumpBtnPressed);

        if (Input.GetButton("Fire1"))
        {
            weaponController.Shoot();
            weaponController.SetShootingAnimation(true);
        }
        else
        {
            weaponController.SetShootingAnimation(false);
        }
    }
}
