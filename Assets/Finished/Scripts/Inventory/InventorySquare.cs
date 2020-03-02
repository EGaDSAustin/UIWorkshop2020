using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySquare : MonoBehaviour
{
    public static List<InventorySquare> Squares = new List<InventorySquare>();
    private RectTransform _rt;

    public Vector2 Position => _rt.position;
    private void Awake()
    {
        Squares.Add(this);
        _rt = GetComponent<RectTransform>();
    }
 
    private void OnDestroy()
    {
        Squares.Remove(this);
    }
}
