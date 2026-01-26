using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class SpikeTrap : MonoBehaviour
{
    private float popDuration = 0.2f; // Super fast for surprise
                                      // Auto-destroy after (performance)


    // trigger the pop-up animation
    public void PopUp(Vector3 targetPosition)
    {
        StartCoroutine(PopUpCoroutine(targetPosition));
    }


    //trigger the pop-up animation coroutine
    private IEnumerator PopUpCoroutine(Vector3 targetPosition)
    {
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < popDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPosition, elapsed / popDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

        
    }
   
}