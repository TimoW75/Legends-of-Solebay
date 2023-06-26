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
    public GameManager gameManager;

    private Vector3 startPos;
    [SerializeField] private AudioSource clueSound;


    [SerializeField] private GameObject mapButton;
    public float moveDistance = 1.0f;    // Distance to move up and down
    public float moveSpeed = 1.0f;       // Speed of movement
    public float duration = 2.0f;        // Total duration of movement

    private Vector3 startPosition;       // Initial position of the object

    private void Start()
    {
        startPos = _clueImage.transform.position;
        _clueImage.SetActive(false);

        startPosition = mapButton.transform.position;

        if (clue != null)
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
        gameManager.AddClue();
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

        StartCoroutine(MoveUpDown());   
        openMap._children[clueChildNumber] = true;

        compass.removeQuestMarker(questMarker);

        if(gameManager.clueNumberFound == 5)
        {
            gameManager.endingScene();
        }

    }


    private IEnumerator MoveUpDown()
    {
        float timer = 0.0f;
        float verticalPosition = startPosition.y;
        Debug.Log("MoveUpDown");

        while (timer < duration)
        {
            // Move up
            while (verticalPosition < startPosition.y + moveDistance && timer < duration)
            {
                verticalPosition += moveSpeed * Time.deltaTime;
                mapButton.transform.position = new Vector3(startPosition.x, verticalPosition, startPosition.z);
                timer += Time.deltaTime;
                yield return null;
            }

            // Move down
            while (verticalPosition > startPosition.y && timer < duration)
            {
                verticalPosition -= moveSpeed * Time.deltaTime;
                mapButton.transform.position = new Vector3(startPosition.x, verticalPosition, startPosition.z);
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
