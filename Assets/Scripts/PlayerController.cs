using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private float ForceValue;
    [SerializeField] private float _gravityValue;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;

    public GameObject _startButton;

    private AudioSource _audioSource;

    private bool IsOnGround = true;
    public bool GameOver = false;
    private Animator playerAnim;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        _audioSource= GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityValue;
        dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            _playerRb.AddForce(Vector3.up * ForceValue,ForceMode.Impulse);
            dirtParticle.Stop();
            _audioSource.PlayOneShot(_jumpSound, 1f);
            playerAnim.SetTrigger("Jump_trig");
            IsOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirtParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER!!!");
            GameOver = true;
            _audioSource.PlayOneShot(_crashSound, 1f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
        
    }

    public void StarterGame()
    {
        _startButton.SetActive(false);
        Time.timeScale = 1f;
    }
}
