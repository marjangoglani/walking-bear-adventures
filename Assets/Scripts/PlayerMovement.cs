using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        player.position = player.position + new Vector3(horizontalDirection, 0);
    }
}
