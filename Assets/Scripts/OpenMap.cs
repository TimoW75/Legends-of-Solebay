using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    [SerializeField] private GameObject _map;

    [SerializeField] public List<bool> _children;
    [SerializeField] public GameObject[] childObjects;

    private void Start()
    {
        _map.SetActive(false);
    }
    
    public void toggleMap()
    {
        if (_map.activeInHierarchy)
        {
            foreach (var child in childObjects)
            {
                child.SetActive(false);
            }
            _map.SetActive(false);

        }
        else
        {
            _map.SetActive(true);

            for (var i = 0; i < _children.Count; i++)
            {
                if (_children[i])
                {
                    childObjects[i].SetActive(true);
                }
            }
        }
    }

}
