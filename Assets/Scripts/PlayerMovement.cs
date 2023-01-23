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
            player.localScale = new Vector3(-1, player.localScale.y);       // flip to left walky
            IsFacingRight = false;

        }
        else if (horizontalDirection > 0)
        {
            // set horizontal walky animation
            animator.SetInteger("HorSpeed", 1);
            if (!IsFacingRight)
            {
                player.localScale = new Vector3(1, player.localScale.y);    // flip back to right walky
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
 * 2. make the animation for back/forward walking
 * 4. create collision with bear and apple
 * 5. butoon appears when it gets in an area around the apple (trigger)
 * 6. when you click E, choices appear 
 * 
 * --------------------------
 * 1. make the background completely blue tiles
 * 2. write a script that randomly adds cloud sprites, but they shouldn't be added on to pof eachother
 * 3. put each cloud in its own canvas and different pngs
 */