using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneControllerBack : MonoBehaviour
{

    public void PlayCutscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   
    }
}