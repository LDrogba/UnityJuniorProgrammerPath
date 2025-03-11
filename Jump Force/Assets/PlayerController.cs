using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityForceModifier = 10f;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    ParticleSystem smokeParticles;
    [SerializeField]
    ParticleSystem dirtParticles;
    [SerializeField]
    AudioClip jumpClip;
    [SerializeField]
    AudioClip dieClip;

    Rigidbody rb;
    Animator anim;
    AudioSource playerAudio;
    bool isGrounded = true;
    bool isPlayerActive = true;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = Vector3.down * gravityForceModifier;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticles.Play();
            isGrounded = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<MoveLeft>().setSpeed(0f);
            dirtParticles.Stop();
            smokeParticles.Play();
            playClipOnce(dieClip);
            gameOver();
        }
    }

    void gameOver()
    {
        //rb.detectCollisions = false;
        //rb.isKinematic = true;
        //transform.Rotate(-90, 0, 0);
        //transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);
        isPlayerActive = false;
        gameOverPanel.SetActive(true);
        //anim.SetFloat("Speed_f", 0f);
        anim.SetBool("Death_b", true);
        anim.SetInteger("DeathType_int", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isPlayerActive)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            isGrounded = false;
            dirtParticles.Stop();
            playClipOnce(jumpClip);
        }
    }

    void playClipOnce(AudioClip clip)
    {
        playerAudio.PlayOneShot(clip, 1f);
    }
}
