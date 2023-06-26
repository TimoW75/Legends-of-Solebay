using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{

    [SerializeField] public GameObject prefabIcon;
    public List<QuestMarker> questMarkers = new List<QuestMarker>();

    [SerializeField] private RawImage compassImage;
    [SerializeField] private Transform player;

    float compassUnit;

    [SerializeField] private QuestMarker one;
    [SerializeField] private QuestMarker two;
    [SerializeField] private QuestMarker three;
    [SerializeField] private QuestMarker four;
    [SerializeField] private QuestMarker five;

    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;
        addQuestMarker(one);
        addQuestMarker(two);
        addQuestMarker(three);
        addQuestMarker(four);
        addQuestMarker(five);
    }

    private void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);

        foreach (QuestMarker marker in questMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompas(marker);
        }   
    }

    public void addQuestMarker(QuestMarker marker)
    {
        GameObject newMarker = Instantiate(prefabIcon, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;
        questMarkers.Add(marker);
    }

    Vector2 GetPosOnCompas (QuestMarker maker)  
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(maker.position - playerPos, playerFwd);

        return new Vector2(compassUnit * angle, 0f);
    }

    public void removeQuestMarker(QuestMarker marker)
    {
        questMarkers.Remove(marker);
        Destroy(marker.image.gameObject);
    }
}
