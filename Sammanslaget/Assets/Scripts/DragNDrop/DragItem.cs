using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragItem : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    public bool SetDragActive(bool state) => DragActive = state;

    bool DragActive = false;

    CanvasGroup canvasGroup;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform.anchoredPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!DragActive) { return; }
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!DragActive) { return; }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!DragActive) { return; }
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = transform.parent.GetComponent<RectTransform>().anchoredPosition;
    }
}
