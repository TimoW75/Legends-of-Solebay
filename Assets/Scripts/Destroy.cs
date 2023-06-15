using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float lifetime = 5f;

    private void Start()
    {
        Invoke("DestroyObject", lifetime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
