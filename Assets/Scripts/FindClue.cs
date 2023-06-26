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
    private bool givenClue = false;

    public Transform target;
    public float speed = 150f;

    [SerializeField] private int clueChildNumber;
    [SerializeField] private QuestMarker questMarker;

    public OpenMap openMap;
    public Compass compass;
    public ShowInlineClue showInlineClue;

    private Vector3 startPos;
    [SerializeField] private AudioSource clueSound;

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
            showInlineClue.ShowClue();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clue.SetActive(false);
            if(!givenClue)
            {
                givenClue = true;
                _clueImage.SetActive(true);
                _clueImage.GetComponent<Image>().sprite = clueImage;
                clueSound.Play();
                StartCoroutine(MoveToTarget(_clueImage, 0f, 1f, fadeDuration));
            }
            showInlineClue.hideClue();

        }
    }

    public void GiveClue()
    {
        if (!givenClue)
        {
            givenClue = true;
            _clueImage.SetActive(true);
            _clueImage.GetComponent<Image>().sprite = clueImage;
            clueSound.Play();
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

        float positionThreshold = 0.1f; // Adjust this threshold value as needed
        while (Vector3.Distance(_clueImage.transform.position, target.position) > positionThreshold)
        {
            Vector3 newPosition = Vector3.MoveTowards(_clueImage.transform.position, target.position, speed * Time.deltaTime);
            _clueImage.transform.position = newPosition;
            float t = (Time.time - startTime) / duration;
            color.a = Mathf.Lerp(endAlpha, startAlpha, t);
            thisImage.color = color;
            yield return null;
        }

        _clueImage.transform.position = startPos;
        _clueImage.SetActive(false);

        openMap._children[clueChildNumber] = true;

        compass.removeQuestMarker(questMarker);
    }
}
