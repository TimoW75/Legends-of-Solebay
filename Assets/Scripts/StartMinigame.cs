using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _minigameCanvas;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject MinigameButton;

    public bool minigameStarted = false;

    public void Startminigame()
    {
        if (!minigameStarted)
        {
            mainCanvas.SetActive(false);
            _minigameCanvas.SetActive(true);
            MinigameButton.SetActive(false);
        }
    }
}
