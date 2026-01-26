using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitDoor : MonoBehaviour
{
   
    public string nextLevelName;
    public ScreenFader screenFader;
    private void OnTriggerEnter2D(Collider2D other)
    {

        // Logic to check if the player has the key
        PlayerInputController player = other.GetComponent<PlayerInputController>();

        if (player != null && player.hasKey)
            {
                // Add logic for reaching the goal, e.g., load next level
                Debug.Log("Goal reached!");
                screenFader.FadeToNextLevel(nextLevelName);
       
            }

        else
        {
            Debug.Log("You need a key to reach the goal!");
        }





    }


}
