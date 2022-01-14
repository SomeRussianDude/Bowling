using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 launchSpeed;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;

        _audioSource = GetComponent<AudioSource>();
    }

    public void Launch(Vector3 velocity)
    {
        _rigidbody.useGravity = true;
        _rigidbody.velocity = velocity;
        _audioSource.Play();
    }
}