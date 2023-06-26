using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInlineClue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clueText;

    void Start()
    {
        clueText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ShowClue()
    {

        clueText.gameObject.SetActive(true);
        
    }
    public void hideClue()
    {
        if (clueText.gameObject.activeInHierarchy)
        {
            clueText.gameObject.SetActive(false);
        }
    }
}
