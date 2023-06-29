using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMiniGameButton : MonoBehaviour
{
    [SerializeField] private GameObject minigameButton;
    public StartMinigame startMinigame;
    void Start()
    {
        minigameButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !startMinigame.minigameStarted)
        {
            minigameButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && minigameButton.activeInHierarchy)
        {
            minigameButton.SetActive(false);
        }
    }
}
