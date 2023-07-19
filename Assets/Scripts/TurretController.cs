using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform horizontalRotation;
    [SerializeField] private Transform verticalRotation;

    [Header("Angles")]
    [SerializeField, Tooltip("X is minimum angle, Y is maximum angle")] private Vector2 horizontalAngles;
    [SerializeField, Tooltip("X is minimum angle, Y is maximum angle")] private Vector2 verticalAngles;

    private Vector3 target;

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    private void Update()
    {
        // Calculate the direction to the target
        Vector3 directionToTarget = target - transform.position;

        // Calculate the rotation to look at the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Calculate the additional rotation for horizontalRotation
        float horizontalRotationAngle = targetRotation.eulerAngles.y;
        float horizontalClampedAngle = ClampAngle(horizontalRotationAngle, horizontalAngles.x, horizontalAngles.y);
        Quaternion horizontalRotationDelta = Quaternion.Euler(0f, 0f, horizontalClampedAngle);

        // Calculate the additional rotation for verticalRotation
        float verticalRotationAngle = targetRotation.eulerAngles.x * -1f;
        float verticalClampedAngle = ClampAngle(verticalRotationAngle, verticalAngles.x, verticalAngles.y);
        Quaternion verticalRotationDelta = Quaternion.Euler(0f, verticalClampedAngle, 0f);

        // Apply the rotations to horizontalRotation and verticalRotation
        horizontalRotation.localRotation = horizontalRotationDelta;
        verticalRotation.localRotation = verticalRotationDelta;
    }

    // Функция для ограничения угла в пределах заданных значений
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -180f) angle += 360f;
        if (angle > 180f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}