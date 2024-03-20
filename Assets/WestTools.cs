using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestTools
{
    // Trigonometric Functions
    /// <summary>
    /// Returns the sine of the specified angle in radians.
    /// </summary>
    public static float sin(float f)
    {
        return Mathf.Sin(f);
    }

    /// <summary>
    /// Returns the cosine of the specified angle in radians.
    /// </summary>
    public static float cos(float f)
    {
        return Mathf.Cos(f);
    }

    // Square Root Function
    /// <summary>
    /// Returns the square root of a specified number.
    /// </summary>
    public static float sqrt(float f)
    {
        return Mathf.Sqrt(f);
    }

    /// <summary>
    /// Returns the square of a specified number.
    /// </summary>
    public static float sqr(float f)
    {
        return Mathf.Pow(f, 2);
    }

    // Rounding Function
    /// <summary>
    /// Rounds a floating-point value to the nearest integer.
    /// </summary>
    public static float round(float f)
    {
        return Mathf.Round(f);
    }

    // Exponential Function
    /// <summary>
    /// Returns a specified number raised to the specified power.
    /// </summary>
    public static float pow(float f, float fx)
    {
        return Mathf.Pow(f, fx);
    }

    // Logarithmic Function
    /// <summary>
    /// Returns the natural (base e) logarithm of a specified number.
    /// </summary>
    public static float log(float f, float p)
    {
        return Mathf.Log(f, p);
    }

    // Linear Interpolation Functions
    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    public static float lerp(float a, float b, float t)
    {
        return Mathf.Lerp(a, b, t);
    }

    /// <summary>
    /// Linearly interpolates between two angles.
    /// </summary>
    public static float lerpAngle(float a, float b, float t)
    {
        return Mathf.LerpAngle(a, b, t);
    }

    // Constants
    /// <summary>
    /// Represents positive infinity.
    /// </summary>
    public static float infinity = Mathf.Infinity;

    /// <summary>
    /// Represents the mathematical constant pi (π).
    /// </summary>
    public static float pi = Mathf.PI;

    /// <summary>
    /// Gets the absolute value of the given float
    /// </summary>
    public static float abs(float f)
    {
        return Mathf.Abs(f);
    }

    // Inverse Lerp Function
    /// <summary>
    /// Calculates the linear parameter t that produces the interpolant value within the range [a, b].
    /// </summary>
    public static float inverseLerp(float a, float b, float v)
    {
        return Mathf.InverseLerp(a, b, v);
    }

    // Tangent Function
    /// <summary>
    /// Returns the tangent of the specified angle in radians.
    /// </summary>
    public static float tan(float f)
    {
        return Mathf.Tan(f);
    }

    // Conversion Functions
    /// <summary>
    /// Converts a 2D Vector to a 3D Vector by setting the z-component to 0.
    /// </summary>
    public static Vector3 position2Dto3D(Vector2 x)
    {
        return new Vector3(x.x, x.y);
    }

    public static Vector2 position3Dto2D(Vector3 x)
    {
        return new Vector2(x.x, x.y);
    }

    public static Vector3 rotationZ(float z)
    {
        return new Vector3(0, 0, z);
    }

    // Direction Vectors
    /// <summary>
    /// Represents the up direction in 3D space.
    /// </summary>
    public static Vector3 up = Vector3.up;

    /// <summary>
    /// Represents the left direction in 3D space.
    /// </summary>
    public static Vector3 left = Vector3.left;

    /// <summary>
    /// Represents the right direction in 3D space.
    /// </summary>
    public static Vector3 right = Vector3.right;

    /// <summary>
    /// Represents the down direction in 3D space.
    /// </summary>
    public static Vector3 down = Vector3.down;

    /// <summary>
    /// Represents the forward direction in 3D space.
    /// </summary>
    public static Vector3 fwd = Vector3.forward;

    /// <summary>
    /// Represents the backward direction in 3D space.
    /// </summary>
    public static Vector3 back = Vector3.back;

    // Rigidbody Functions
    /// <summary>
    /// Gets the Rigidbody2D component attached to a GameObject.
    /// </summary>
    public static Rigidbody2D getRb2D(GameObject on)
    {
        Rigidbody2D rb = on.GetComponent<Rigidbody2D>();
        return rb;
    }

    /// <summary>
    /// Gets the Rigidbody component attached to a GameObject.
    /// </summary>
    public static Rigidbody getRb(GameObject on)
    {
        Rigidbody rb = on.GetComponent<Rigidbody>();
        return rb;
    }

    // Closest and Farthest Transform Functions
    /// <summary>
    /// Finds the closest Transform from an array of Transforms to a specified point.
    /// </summary>
    public static Transform GetClosest(Transform[] tr, Transform from)
    {
        Transform closest = null;
        float minDist = Mathf.Infinity;
        Vector3 pos = from.position;

        foreach (Transform t in tr)
        {
            float dist = Vector3.Distance(t.position, pos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        return closest;
    }

    /// <summary>
    /// Finds the farthest Transform from an array of Transforms to a specified point.
    /// </summary>
    public static Transform GetFarthest(Transform[] tr, Transform from)
    {
        Transform farthest = null;
        float maxDist = -Mathf.Infinity;
        Vector3 pos = from.position;

        foreach (Transform t in tr)
        {
            float dist = Vector3.Distance(t.position, pos);
            if (dist > maxDist)
            {
                farthest = t;
                maxDist = dist;
            }
        }

        return farthest;
    }

    /// <summary>
    /// Calculates the cross product of two vectors.
    /// </summary>
    public Vector3 cross(Vector3 f, Vector3 b)
    {
        return Vector3.Cross(f, b);
    }

    /// <summary>
    /// Returns a normalized vector.
    /// </summary>
    public Vector3 norm(Vector3 f)
    {
        return Vector3.Normalize(f);
    }

    /// <summary>
    /// Calculates the dot product of two vectors.
    /// </summary>
    public float dot(Vector3 f, Vector3 b)
    {
        return Vector3.Dot(f, b);
    }

    /// <summary>
    /// Linearly interpolates between two colors.
    /// </summary>
    public Color lerpcolor(Color a, Color b, float t)
    {
        return Color.Lerp(a, b, t);
    }

    /// <summary>
    /// Generates a random float within a specified range.
    /// </summary>
    public float r_range(float f, float b)
    {
        return Random.Range(f, b);
    }

    /// <summary>
    /// Calculates the volume of a cube.
    /// </summary>
    public static float volume(Transform currentObject)
    {
        return (currentObject.localScale.x * currentObject.localScale.y * currentObject.localScale.z);
    }

    // Cubic easing in function
    static float cubicEaseIn(float t)
    {
        return t * t * t;
    }

    /// <summary>
    // Lerping function with cubic easing in
    /// </summary>
    public static float easeIn(float a, float b, float t)
    {
        t = Mathf.Clamp01(t);
        t = cubicEaseIn(t);
        return Mathf.Lerp(a, b, t);
    }

    // Cubic easing out function
    static float cubicEaseOut(float t)
    {
        t = 1f - t;
        return 1f - (t * t * t);
    }

    /// <summary>
    // Lerping function with cubic easing out
    /// </summary>
    public static float easeOut(float a, float b, float t)
    {
        t = Mathf.Clamp01(t);
        t = cubicEaseOut(t);
        return Mathf.Lerp(a, b, t);
    }

    // Cubic easing in-out function
    static float cubicEaseInOut(float t)
    {
        t *= 2f;
        if (t < 1f)
        {
            return 0.5f * t * t * t;
        }
        t -= 2f;
        return 0.5f * (t * t * t + 2f);
    }

    /// <summary>
    // Lerping function with cubic easing in-out
    /// </summary>
    public static float easeInOut(float a, float b, float t)
    {
        t = Mathf.Clamp01(t);
        t = cubicEaseInOut(t);
        return Mathf.Lerp(a, b, t);
    }

    public static float fixedDeltaTime = Time.fixedDeltaTime;
    public static float deltaTime = Time.deltaTime;

    public static Vector3 absVector3(Vector3 v)
    {
        return new Vector3(abs(v.x), abs(v.y), abs(v.z));
    }

    public static Vector2 absVector2(Vector2 v)
    {
        return new Vector2(abs(v.x), abs(v.y));
    }

    
    public static Transform[] gameobjectArrayToTransform(GameObject[] objs)
    {
        List<Transform> trans = new List<Transform>();
        for (int i = 0; i < objs.Length; i++)
        {
            trans.Add(objs[i].transform);
        }
        return trans.ToArray();
    }
}
