using UnityEngine;

public class TshirtFunction : MonoBehaviour
{
    public PlayerMovement playerInstance;

    public Animator tshirtAnimation;

    public void Update()
    {
        if (playerInstance.directionX != 0)
            tshirtAnimation.SetBool("sideways", true);
        else
            tshirtAnimation.SetBool("sideways", false);  
    }
}
