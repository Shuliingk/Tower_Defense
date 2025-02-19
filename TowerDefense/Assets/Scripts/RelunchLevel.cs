using UnityEngine;
using UnityEngine.SceneManagement;

public class RelunchLevel : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Relancer le niveau
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
