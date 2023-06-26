using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int clueNumberFound;
    [SerializeField] public GameObject map;

    public OpenMap openMap;
    public void AddClue()
    {
        clueNumberFound++;
    }

    public void endingScene()
    {
        StartCoroutine(endingSceneStart()); 
    }
    private IEnumerator endingSceneStart()
    {
        yield return new WaitForSeconds(1);
        openMap.toggleMap();

    }

}
