using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Set this in the Inspector to the name of the scene you want to load
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene("Level_2");
        }
    }
}
