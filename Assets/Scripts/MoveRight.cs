using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 1f;  // The speed at which the image moves

    private RectTransform rectTransform;
    private float targetX;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        targetX = rectTransform.anchoredPosition.x + 200f;  // Adjust the distance as needed
    }

    private void Update()
    {
        float currentX = rectTransform.anchoredPosition.x;
        float newX = Mathf.MoveTowards(currentX, targetX, speed * Time.deltaTime);
        rectTransform.anchoredPosition = new Vector2(newX, rectTransform.anchoredPosition.y);
    }
}
