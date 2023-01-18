using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    private float speed = 1f;
    public Animator animator;
    private bool IsFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");

        float horizontalSpeed = horizontalDirection * speed * Time.deltaTime;
        float verticalSpeed = verticalDirection * speed * Time.deltaTime;


        // FIXME: if verticalDirection is negative, ge tthe transform of the player and flip it around the y axis
        if (horizontalDirection < 0)
        {
            // FIXME: I will probably have to either change the animation manually (probably not possible)
            // or I can use the variables that I defined for the checking of animator

            // set horizontal walky animation
            animator.SetInteger("HorSpeed", 1);
            player.localScale = new Vector3(-1, player.localScale.y);       // flip
            IsFacingRight = false;

        }
        else if (horizontalDirection > 0)
        {
            // set horizontal walky animation
            animator.SetInteger("HorSpeed", 1);
            if (!IsFacingRight)
            {
                player.localScale = new Vector3(-1, player.localScale.y);
                IsFacingRight = true;
            }
        }
        else
        {
            // animation idle
            animator.SetInteger("HorSpeed", 0);
            animator.SetInteger("VerSpeed", 0);
        }

        player.position = player.position + new Vector3(horizontalSpeed, verticalSpeed);
    }
}



/*
 * Today:
 * 2. implement movement script
 * 3. fix animations on the bear (left and right walking)
 */