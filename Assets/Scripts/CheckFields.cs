using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFields : MonoBehaviour
{

    [SerializeField] private GameObject[] checkFields;
    [SerializeField] private GameObject _minigameCanvas;
    [SerializeField] private GameObject mainCanvas;

    [SerializeField] private AudioSource goodPlace;
    [SerializeField] private AudioSource wrongPlace;

    public FindClue findClue;
    public StartMinigame startMinigame;
    private int checkFieldsCount;
    public void checkFilledFields()
    {
        checkFieldsCount = 0;
        foreach (GameObject checkField in checkFields)
        {
            if (checkField.transform.childCount != 0)
            {
                if (checkField.name == checkField.transform.GetChild(0).name)
                {
                    checkFieldsCount++;
                    goodPlace.Play();
                }
                else
                {
                    wrongPlace.Play();
                }
            }

        }

        print(checkFieldsCount);
        if(checkFieldsCount == 6)
        {
            mainCanvas.SetActive(true);
            _minigameCanvas.SetActive(false);
            findClue.GiveClue();
            startMinigame.minigameStarted = true;  
        }
    }
}
