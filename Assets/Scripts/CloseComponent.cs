using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseComponent : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private GameObject[] buttons;




    // Update is called once per frame
    public void close()
    {
        Object.SetActive(false);

        if(buttons.Length != 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
        }
    }
    public void open()
    {
        Object.SetActive(true);
    }
}
