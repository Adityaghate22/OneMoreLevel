using UnityEngine;

public class Collectibles : MonoBehaviour
{
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        // collectible logic
        PlayerInputController player = other.GetComponent<PlayerInputController>();
        if (other.CompareTag("Player"))
        {
            if (player != null)
            {
           
                player.hasKey = true;
                Debug.Log("Collectible collected!");
                Destroy(gameObject);
            }
            
            
        }

    }

}
