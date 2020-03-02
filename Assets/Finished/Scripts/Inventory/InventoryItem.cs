using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rt;
    private bool _set = true;
    private Vector2 _startPos;
    [SerializeField] private float _lockThreshold = 10f;
    private void Awake()
    {
        _rt = GetComponent<RectTransform>();
        _startPos = _rt.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start drag");

        _set = false;
        _startPos = _rt.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rt.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");

        InventorySquare closest = FindClosestSquare();

        _set = true;

        if (Vector2.Distance(closest.Position, _rt.position) > _lockThreshold)
            _rt.position = _startPos;
        else
            _rt.position = closest.transform.position;
    }

    private InventorySquare FindClosestSquare()
    {
        float minDistance = float.MaxValue;
        InventorySquare closest = null;
        
        foreach (InventorySquare square in InventorySquare.Squares)
        {
            float distance = Vector2.Distance(square.Position, _rt.position);
            if (minDistance > distance)
            {
                closest = square;
                minDistance = distance;
            }
        }

        return closest;
    }
}
