
using UnityEngine;
using UnityEngine.UI;

public class ShowClueController : MonoBehaviour
{
    [SerializeField] private Image[] images;
    void Start()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
        ShowClue(0);

    }


    public void ShowClue(int index)
    {
        images[index].enabled = true;
    }
}
