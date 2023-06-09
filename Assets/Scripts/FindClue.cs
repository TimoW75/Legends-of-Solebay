using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClue : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You found a clue!");
        Destroy(gameObject);    
    }
}
