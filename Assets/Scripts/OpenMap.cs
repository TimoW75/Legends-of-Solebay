using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    [SerializeField]private GameObject _map;
    public ShowClueController showClueController;
    private void Start()
    {
        _map.SetActive(false);
    }
    
    public void toggleMap()
    {
        if (_map.activeInHierarchy)
        {
            _map.SetActive(false);
        }
        else
        {
            _map.SetActive(true);
        }
    }

}
