using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public PlayerMovement playerInstance;

    public Transform player;
    public Vector3 offset;
    public float lerp;
    public float movementOffset;

    void FixedUpdate () {
        offset = new Vector3(playerInstance.directionX * movementOffset, playerInstance.directionY * movementOffset, -10);
        transform.position = Vector3.Lerp (transform.position , player.position + offset, lerp);
    }
}
