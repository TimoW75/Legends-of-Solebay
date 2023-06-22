using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FindClue : MonoBehaviour
{
    [SerializeField] private GameObject clue;
    [SerializeField] private GameObject _clueImage;
    [SerializeField] private float fadeDuration = 1f;

    [SerializeField] private Sprite clueImage;

    public Transform target;
    public float speed = 150f;

    [SerializeField] private int clueChildNumber;

    public OpenMap openMap;

    private Vector3 startPos;

    private void Start()
    {
        startPos = _clueImage.transform.position;
        _clueImage.SetActive(false);

        if(clue != null)
        {
            clue.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (clue != null && collision.gameObject.CompareTag("Player"))
        {
            clue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clue.SetActive(true);
            _clueImage.SetActive(true);
            _clueImage.GetComponent<Image>().sprite = clueImage;

            StartCoroutine(MoveToTarget(_clueImage, 0f, 1f, fadeDuration));
        }
    }

    private IEnumerator MoveToTarget(GameObject image, float startAlpha, float endAlpha, float duration)
    {
        Image thisImage = image.GetComponent<Image>();

        Color color = thisImage.color;
        color.a = startAlpha;
        thisImage.color = color;

        float startTime = Time.time;

        while (_clueImage.transform.position != target.position)
        {
            Vector3 newPosition = Vector3.MoveTowards(_clueImage.transform.position, target.position, speed * Time.deltaTime);
            _clueImage.transform.position = newPosition;
            float t = (Time.time - startTime) / duration;
            color.a = Mathf.Lerp(endAlpha, startAlpha, t);
            thisImage.color = color;
            yield return null;
        }
        color.a = endAlpha;
        _clueImage.transform.position = startPos;

        _clueImage.SetActive(true);
        openMap._children[clueChildNumber] = true;
    }
}
