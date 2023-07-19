using UnityEngine;
using UnityEngine.Events;

public class ZombieEscapeHandler : MonoBehaviour
{
    public static UnityEvent ZombieBreakthrough = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            Debug.Log("Zombie breakthrough");
            zombie.gameObject.SetActive(false);
            ZombieBreakthrough?.Invoke();
        }
    }
}