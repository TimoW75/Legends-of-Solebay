using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{

    private void Start()
    {
        PlayCutscene(0);
    }

    public void PlayCutscene(int index)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   
    }
}