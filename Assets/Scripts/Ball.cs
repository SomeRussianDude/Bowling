using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float launchSpeed = 200;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        Launch();
    }

    private void Launch()
    {
        _rigidbody.velocity = new Vector3(0, 0, launchSpeed);

        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

}
