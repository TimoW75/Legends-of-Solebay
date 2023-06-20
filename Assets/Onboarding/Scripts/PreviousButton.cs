using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousButton : MonoBehaviour
{


    public void NextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   
    }
}