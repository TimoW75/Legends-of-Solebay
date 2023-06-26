using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMiniGameButton : MonoBehaviour
{
    [SerializeField] private GameObject minigameButton;
    void Start()
    {
        minigameButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            minigameButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            minigameButton.SetActive(false);
        }
    }
}
