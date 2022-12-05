using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Rool;
    public float Sensitivity;

    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Rool.Rotate(0, -delta.x * Sensitivity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
