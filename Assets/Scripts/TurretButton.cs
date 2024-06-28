using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TurretButton : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    Image image;

    public Camera mainCam;
    public GameObject turretToBuild;

    GameObject currentPlatform;
    Vector3 initialPos;

    void OnTriggerEnter(Collider col)
    {
        currentPlatform = col.gameObject;
    }

    void OnTriggerExit(Collider col)
    {
        currentPlatform = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.65f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Time.timeScale != 0)
        {
            Vector3 mouseVec = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mouseVec.z = 0f;
            rectTransform.position = mouseVec;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.SetActive(false);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        if (currentPlatform != null && !currentPlatform.GetComponent<Plateform>().isOccupied && GameManager.Instance.currentGold >= turretToBuild.GetComponent<Turret>().cost)
        {
            GameObject clone = Instantiate(turretToBuild);
            clone.transform.position = new Vector3(currentPlatform.transform.position.x - 0.2f, currentPlatform.transform.position.y + 0.2f, currentPlatform.transform.position.z);
            currentPlatform.GetComponent<Plateform>().isOccupied = true;
            GameManager.Instance.currentGold -= turretToBuild.GetComponent<Turret>().cost;
        }
        transform.position = initialPos;
    }

    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = turretToBuild.GetComponent<Turret>().cost.ToString();
        initialPos = transform.position;
        rectTransform = GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.Instance.currentGold < turretToBuild.GetComponent<Turret>().cost)
            image.color = new Color(0, 0, 0, image.color.a);
        else
            image.color = new Color(1, 1, 1, image.color.a);

    }
}
