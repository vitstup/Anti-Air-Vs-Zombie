using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TurretController controller;
    [SerializeField] private AbstractGun gun;

    private Vector3 targetpos;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 100f;

            targetpos = Camera.main.ScreenToWorldPoint(mousePos);

            controller.SetTarget(targetpos);

            if (Input.GetMouseButtonDown(0)) gun.TryToShoot();
        }
    }

    private void OnDrawGizmos()
    {
        if (targetpos != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetpos, 0.33f);
        }
    }
}