using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(1f * Time.deltaTime, 5f * Time.deltaTime, 0);
    }
}