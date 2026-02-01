using UnityEngine;

public class PatrolPlatform : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public Transform pointA;
    public Transform pointB;

    [Header("Movement")]
    public float speed = 2f;
    public float reachDistance = 0.05f;

    // internal state (THIS is what you were missing)
    private Vector2 target;
    private bool goingToB = true;

    void Awake()
    {
        // safety
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Start()
    {
        // start at A, move to B
        rb.position = pointA.position;
        target = pointB.position;
        goingToB = true;
    }

    void FixedUpdate()
    {
        // move platform
        rb.MovePosition(
            Vector2.MoveTowards(
                rb.position,
                target,
                speed * Time.fixedDeltaTime
            )
        );

        // switch direction ONCE when reached
        if (goingToB && (rb.position - (Vector2)pointB.position).sqrMagnitude <= reachDistance * reachDistance)
        {
            goingToB = false;
            target = pointA.position;
        }
        else if (!goingToB && (rb.position - (Vector2)pointA.position).sqrMagnitude <= reachDistance * reachDistance)
        {
            goingToB = true;
            target = pointB.position;
        }
    }
}
