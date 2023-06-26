using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private float initialZ;
    private Image image;
    [SerializeField] private GameObject dragBoat;
    [SerializeField] private Canvas canvas;

    public CheckFields checkFields;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        Transform dragParent = transform.root.Find("Minigame");
        transform.SetParent(dragParent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

        initialZ = transform.position.z; 
        canvas.sortingOrder += 1; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        if (!dragBoat.GetComponent<MouseFollow>().enabled)
        {
            dragBoat.GetComponent<MouseFollow>().enabled = true;
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        image.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        dragBoat.GetComponent<MouseFollow>().enabled = false;
        canvas.sortingOrder -= 1;

        checkFields.checkFilledFields();
    }
}
