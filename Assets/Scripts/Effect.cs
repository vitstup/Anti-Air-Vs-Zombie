using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    public void Play()
    {
        particles.Play();
    }

    private void Update()
    {
        if (!particles.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}