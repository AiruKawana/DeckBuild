using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    private Vector3 prePos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        prePos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool flg = true;

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        foreach(var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("Deck"))
            {
                transform.position = hit.gameObject.transform.position;
                flg = false;
            }
        }

        if (flg)
        {
            transform.position = prePos;
        }
    }
}
