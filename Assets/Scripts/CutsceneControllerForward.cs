using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneControllerForward : MonoBehaviour
{

    public void PlayCutscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   
    }
}