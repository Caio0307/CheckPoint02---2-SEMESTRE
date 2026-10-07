
using Unity.VisualScripting;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    private AudioSource AudioSource;
    

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    
    [Header("Player Move Settings")]
    [SerializeField] private float speed;
    private Vector2 move;


    [Header("Player Jump Settings")]
    [SerializeField] private float JumpForce;
    [SerializeField] private float TempoAtualPulo;
    [SerializeField] private float TempoDuracaoPulo;
    [SerializeField] Transform sensorGround;
    [SerializeField] Vector2 SensorSize;
    [SerializeField] LayerMask layerGround;




    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();

    }


    private void Update()
    {
        Move();
        Jump();
        
    }

    private void FixedUpdate()
    {
        OnMove();
        OnJump();

    }

    private void Move()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")) * speed;
    
        if(move.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(move.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnMove()
    {

        rigidbody.linearVelocity = new Vector2(move.x, rigidbody.linearVelocityY);
        


    }


    private void Jump()
    {
        if(Input.GetButtonDown("Jump")&& Grounded())
        {
            TempoAtualPulo = TempoDuracaoPulo;
        }
        else if(Input.GetButton("Jump")&& TempoAtualPulo > 0)
        {
            TempoAtualPulo -= Time.deltaTime;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            TempoAtualPulo = 0;

        }
    }

    private void OnJump()
    {

        if(TempoAtualPulo > 0)
        {
            rigidbody.AddForce(Vector2.up, ForceMode2D.Impulse);

        }


    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "coin")
        {

           
          

            AudioSource.GetComponent<AudioSource>().Play();

            print("tocou");
            Destroy(collider.gameObject);
        }


    }









    //ENCAPSULAMENTOS 

    public int MoveValue()
    {

        return (int)move.x;
   }

    public int JumpValue()
    {

        return (int)rigidbody.linearVelocityY;

    }












    private bool Grounded()
    {
        return Physics2D.OverlapBox(sensorGround.position, SensorSize, 0,layerGround);


    }





   void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(sensorGround.position, SensorSize);
    }




  
    







   


}
