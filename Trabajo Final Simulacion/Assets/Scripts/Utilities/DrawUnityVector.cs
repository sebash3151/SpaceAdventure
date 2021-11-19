using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrawUnityVector
{
    public static void Draw(this Vector2 vector, Color color)
    {
        Debug.DrawLine(Vector3.zero, vector, color);
    }

    public static void Draw(this Vector2 vector, Vector2 origin, Color color)
    {
        Debug.DrawLine(origin, origin + vector, color);
    }

    public static void Draw(this Vector3 vector, Color color)
    {
        Debug.DrawLine(Vector3.zero, vector, color);
    }

    public static void Draw(this Vector3 vector, Vector3 origin, Color color)
    {
        Debug.DrawLine(origin, origin + vector, color);
    }

    public static void Draw(this Vector4 vector, Color color)
    {
        Debug.DrawLine(Vector3.zero, vector, color);
    }

    public static void Draw(this Vector4 vector, Vector4 origin, Color color)
    {
        Debug.DrawLine(origin, origin + vector, color);
    }
}
