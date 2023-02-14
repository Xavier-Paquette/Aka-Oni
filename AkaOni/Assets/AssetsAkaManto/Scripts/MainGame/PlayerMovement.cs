using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3.0f;
    private Vector2 _movement = new Vector2();
    private Animator _anim;
    private Vector3 spawnPoint;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(-55.66f, 3.35f, 1);
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

    private void Update() {
        UpdateState();
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

    public void CheckPoint(Vector3 newPos) {
        spawnPoint = newPos;
    }
    public void Respawn() {
        transform.position = spawnPoint;
    }
}
