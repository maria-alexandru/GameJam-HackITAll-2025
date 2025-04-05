using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CameraFollow margins;

    // orientation -> true: right -> false: left
    private bool orientation;
    private float move;
    public float speed;
    private Rigidbody2D rigidBody;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        margins = GameObject.Find("Camera").GetComponent<CameraFollow>();
        orientation = true;
        rigidBody = this.GetComponent<Rigidbody2D>();
        player = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if(rigidBody != null)
            rigidBody.linearVelocity = new Vector2(move * speed, 0);

        Orientation();

        // limitez coordonatele
        if(player != null)
            player.position = new Vector3(Mathf.Clamp(player.position.x, margins.getMinX(), margins.getMaxX()), player.position.y, player.position.z) ;
    }

    void Orientation() {
        if(orientation && (move > 0) == true)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            orientation = false;
        } 
        
        if((orientation == false) && (move < 0) == true) {
            
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            orientation = true;
        }
    }
}
