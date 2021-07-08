using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Transform playerSprte;
    public Animator playerAninmation;

    public float playerSpeed;
    public bool canMove = true;
    public int directionX, directionY;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    //TAKING INPUTS FOR MOVEMENT
    public void TakeInputs ()
    {
        directionX = (int)Input.GetAxisRaw("Horizontal");
        directionY = (int)Input.GetAxisRaw("Vertical");

        //HANDLING ANIMATION
        if (directionX != 0)
        {
            playerSprte.localScale = new Vector3(directionX, 1, 1);
            playerAninmation.SetBool("Walking", true);
        }else
            playerAninmation.SetBool("Walking", false);
    }

    public void Update()
    {
        if (canMove)
            TakeInputs();
        else return;
    }

    //ADDING VELOCITY
    public void FixedUpdate()
    {
        player.velocity = new Vector2(directionX, directionY) * playerSpeed;
    }
}
