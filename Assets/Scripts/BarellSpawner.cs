using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarellSpawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60 / 100) * 2; // Spawnrate of cubes (usually ignored for a configurable value)
    private float timer;


    // Update is called once per frame
    void Update()
    {

        if (timer > beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 1)], points[Random.Range(0, 3)]); //Amount of random objects to be spawned, and the amount of random spawnpoints (default set to 2)
            cube.transform.localPosition = Vector3.zero;
            cube.GetComponent<Destroy>().enabled = true;
            timer -= beat;

        }

        timer += Time.deltaTime;

    }
}
