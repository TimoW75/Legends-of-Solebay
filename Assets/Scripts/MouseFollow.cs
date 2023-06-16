using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public RectTransform objectTransform;
    public float followSpeed = 5f;
    private Vector3 targetPosition;

    void Start()
    {
        objectTransform = GetComponent<RectTransform>();
        targetPosition = objectTransform.localPosition;
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            objectTransform.parent as RectTransform,
            Input.mousePosition,
            null,
            out localPoint
        );

        targetPosition = new Vector3(localPoint.x, objectTransform.localPosition.y, objectTransform.localPosition.z);
        objectTransform.localPosition = Vector3.Lerp(objectTransform.localPosition, targetPosition, Time.deltaTime * followSpeed);
    }
}
