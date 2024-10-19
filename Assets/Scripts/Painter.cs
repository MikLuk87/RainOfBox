using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Painter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}