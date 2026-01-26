using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    // Movement parameters
    public float moveSpeed = 5f;
    public float jumpforce = 15f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundxsize;
    public float groundysize;
    public LayerMask groundLayer;
 
    public bool hasKey = false;
    public Transform spawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Grounded();
        Jump();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();


    }
    // check grounded status
    public bool Grounded()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position,new Vector2(groundxsize,groundysize),0, groundLayer);
        return isGrounded;
    }
    //mopvement logic
    private void Move()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocity.y);

    }

    //jump logic
    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    // Visualize ground check area
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(groundxsize, groundysize));
    }


    // traps and hazard logic
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            Die();
        }
    }


    // death and respawn logic
    void Die()
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            rb.linearVelocity = Vector2.zero;
        }
        hasKey = false; // Reset key on death
        ResetTraps();
    }


    //reset traps on death
    void ResetTraps()
    {
        TrapSpawner[] spawners = FindObjectsOfType<TrapSpawner>();
        foreach (TrapSpawner spawner in spawners)
        {
            spawner.Reset();
        }
    }
}