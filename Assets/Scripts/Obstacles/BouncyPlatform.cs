//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField]
    private float _bounceForce;

    private AudioSource _bounceSound;

    private Animator _bounceAnimator;

    private void Awake()
    {
        _bounceAnimator = GetComponent<Animator>();
        _bounceSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallStates>();

        if (ball != null)
        {
            ball.Bounce(_bounceForce);
            _bounceSound.Play();
            _bounceAnimator.SetTrigger("Bounce");
        }
    }
}