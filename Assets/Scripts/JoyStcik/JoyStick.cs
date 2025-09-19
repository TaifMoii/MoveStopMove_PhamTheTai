using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform background;
    private RectTransform handle;

    [Header("Settings")]
    public float handleRange = 100f;
    public float deadZone = 0.1f;
    public bool isFloating = true;

    private Canvas canvas;
    private Camera cam;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public Vector3 Direction => new Vector3(Horizontal, 0, Vertical);

    private void Start()
    {
        background = transform.GetChild(0).GetComponent<RectTransform>();
        handle = background.GetChild(0).GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        cam = canvas.worldCamera;

        if (isFloating) background.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isFloating)
        {
            background.position = eventData.position;
            background.gameObject.SetActive(true);
        }
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        Vector2 radius = background.sizeDelta / 2;

        Horizontal = (eventData.position.x - position.x) / radius.x;
        Vertical = (eventData.position.y - position.y) / radius.y;

        Vector2 input = new Vector2(Horizontal, Vertical);
        input = (input.magnitude > 1.0f) ? input.normalized : input;

        if (input.magnitude < deadZone) input = Vector2.zero;

        handle.anchoredPosition = input * radius * 0.6f;

        Horizontal = input.x;
        Vertical = input.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Horizontal = 0;
        Vertical = 0;
        handle.anchoredPosition = Vector2.zero;

        if (isFloating) background.gameObject.SetActive(false);
    }
}