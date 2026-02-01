using UnityEngine;

public class MoveOb : MonoBehaviour
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

            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)

            {
                Debug.Log("reached point A");

                targetPosition = pointB.position;

            }

            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)

            {

                Debug.Log("reached point B");

                targetPosition = pointA.position;

            }

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    public void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pointA.position, 0.2f);
            Gizmos.DrawSphere(pointB.position, 0.2f);
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }



}
