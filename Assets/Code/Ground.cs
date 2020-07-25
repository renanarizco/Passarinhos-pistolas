using System;
using UnityEngine;

internal class Ground : MonoBehaviour
{
    public static implicit operator Ground(BoxCollider2D v)
    {
        throw new NotImplementedException();
    }
}