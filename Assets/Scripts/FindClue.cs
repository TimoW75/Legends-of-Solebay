using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClue : MonoBehaviour
{
    [SerializeField] private GameObject[] _clue;
    [SerializeField] private GameObject _clueImage;
    [SerializeField] private int clueImageNumber;
    public ShowClueController showClue;

    void Start()
    {
        for (int i = 0; i < _clue.Length; i++)
        {
            _clue[i].SetActive(false);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _clue.Length; i++)
            {
                _clue[i].SetActive(true);
            }
            _clueImage.SetActive(true);

            showClue.EnableImage(clueImageNumber);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _clue.Length; i++)
            {
                _clue[i].SetActive(false);

            }
        }
    }
}
