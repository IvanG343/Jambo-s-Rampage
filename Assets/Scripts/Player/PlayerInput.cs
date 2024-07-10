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
    private WeaponController weaponController;
    private MenuManager menuManager;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        weaponController = GetComponentInChildren<WeaponController>();
        menuManager = GameObject.Find("UICanvas").GetComponent<MenuManager>();
    }

    private void Update()
    {
        if(!menuManager.isPaused)
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

        if(Input.GetKeyDown(KeyCode.P))
        {
            menuManager.OnPauseBtnClick();
        }
    }
}
