using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // müziði baþlatýr
    }
}
