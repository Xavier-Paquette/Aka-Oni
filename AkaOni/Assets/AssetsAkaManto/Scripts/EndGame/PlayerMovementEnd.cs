using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEnd : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3.0f;
    private Vector2 _movement = new Vector2();
    private Animator _anim;
    private Vector3 spawnPoint;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(1.36f, 2.14f, 1);
        transform.position = spawnPoint;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();
        _rb.velocity = _movement * _movementSpeed;
    }

    private void Update()
    {
        UpdateState();
    }
    public void StopMoving() {
        _anim.SetBool("isWalking", false);
        _rb.velocity = new Vector2(0,0);
    }
    void UpdateState()
    {
        if (Mathf.Approximately(_movement.x, 0) && Mathf.Approximately(_movement.y, 0))
        {
            _anim.SetBool("isWalking", false);
        }
        else
        {
            _anim.SetBool("isWalking", true);
        }
        _anim.SetFloat("xDir", _movement.x);
        _anim.SetFloat("yDir", _movement.y);
    }
    public void PlayDeathSound() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

    }
}
