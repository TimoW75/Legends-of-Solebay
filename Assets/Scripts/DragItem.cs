
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    private float initialZ;
    private Image image;
    [SerializeField] private GameObject dragBoat;

    void Start()
    {
        initialZ = transform.position.z;
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        Transform dragParent = transform.root.Find("Tapijt");
        transform.SetParent(dragParent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }


    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        dragBoat.GetComponent<MouseFollow>().enabled = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        dragBoat.GetComponent<MouseFollow>().enabled = false;

    }

}
