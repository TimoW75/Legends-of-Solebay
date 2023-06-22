using UnityEngine;
using UnityEngine.UI;

public class ClickToEnlargeImage : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject gameImageCanvas;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int buttonNumber;


    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        gameImageCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {

        gameImageCanvas.SetActive(true);
        buttons[buttonNumber].SetActive(true);

        gameImageCanvas.GetComponent<Image>().sprite = image;
        gameImageCanvas.GetComponent<Image>().preserveAspect = true;    
    }
}
