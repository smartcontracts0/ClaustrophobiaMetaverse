using UnityEngine;

public class SceneButton : MonoBehaviour
{
    public string sceneName; // Name of the scene to load
    public string interactionText = "Press F to enter the scene";
    public GUISkin customSkin; // Optional: GUI skin for customizing text appearance

    private bool isPlayerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void OnGUI()
    {
        if (isPlayerNear)
        {
            // Use the custom skin if provided
            if (customSkin != null)
            {
                GUI.skin = customSkin;
            }

            // Display the interaction text
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), interactionText);

            // Check for player input
            if (Input.GetKeyDown(KeyCode.F))
            {
                LoadScene();
            }
        }
    }

    private void LoadScene()
    {
        // Load the specified scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
