using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPositionHolder : MonoBehaviour
{
    [SerializeField] private Vector2 oldPosition;
    public Vector2 GetOldPosition() { return oldPosition; }
    public void SetOldPosition(Vector2 OldPosition)
    {
        oldPosition = OldPosition;
    }
}
