using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private Vector3 targetPosition;

    void Start()
    {
      targetPosition = pointB.position;
    }

    void Update()
    {
            if (Vector2.Distance(transform.position,pointA.position) <0.1f)
            {   Debug.Log("reached point A");
                targetPosition = pointB.position;
            }
            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                Debug.Log("reached point B");
               targetPosition = pointA.position;
            }
            
             transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    
}