using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // m�zi�i ba�lat�r
    }
}
