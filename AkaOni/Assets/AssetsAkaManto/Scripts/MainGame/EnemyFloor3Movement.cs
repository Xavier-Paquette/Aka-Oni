using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class EnemyFloor3Movement : MonoBehaviour
{
    [SerializeField] private float _pursuitSpeed = 3f;
    [SerializeField] private float _wanderSpeed = 2f;
    private float _currentSpeed = 3;
    [SerializeField] private float _directionChangeInterval = 0.1f;
    [SerializeField] private bool followPlayer = true;
    private Coroutine _moveCoroutine;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform _targetTransform = null;
    private Vector3 _endPosition;
    
    private CircleCollider2D _circleCollider;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private GameObject MovementMarker1;
    [SerializeField] private GameObject MovementMarker2;
    private Vector3 marker1Pos;
    private Vector3 marker2Pos;
    // Start is called before the first frame update
    void Start()
    {
        marker1Pos = MovementMarker1.transform.position;
        marker2Pos = MovementMarker2.transform.position;
        _endPosition = marker1Pos;
        _anim = GetComponent<Animator>();
        _currentSpeed = _wanderSpeed;
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        StartCoroutine(WanderRoutine());
    }
    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndpoint();
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(Move(_rb, _currentSpeed));
            yield return new WaitForSeconds(_directionChangeInterval);
        }
    }

    void ChooseNewEndpoint()
    {
        if (_endPosition == marker1Pos)
        {
            _endPosition = marker2Pos;
        }
        else {
            _endPosition = marker1Pos;
        }
        
        if (_endPosition.x > transform.position.x)
        {
            _anim.SetBool("isFacingEast", true);
            _anim.SetBool("isFacingNorth", false);
            _anim.SetBool("isFacingSouth", false);
            _anim.SetBool("isFacingWest", false);
        }
        else if (_endPosition.y < transform.position.y)
        {
            _anim.SetBool("isFacingEast", false);
            _anim.SetBool("isFacingNorth", false);
            _anim.SetBool("isFacingSouth", true);
            _anim.SetBool("isFacingWest", false);
        }
        else if (_endPosition.y > transform.position.y)
        {
            _anim.SetBool("isFacingEast", false);
            _anim.SetBool("isFacingNorth", true);
            _anim.SetBool("isFacingSouth", false);
            _anim.SetBool("isFacingWest", false);
        }
        else if (_endPosition.x < transform.position.x)
        {
            _anim.SetBool("isFacingEast", false);
            _anim.SetBool("isFacingNorth", false);
            _anim.SetBool("isFacingSouth", false);
            _anim.SetBool("isFacingWest", true);
        }
    }
    public IEnumerator Move(Rigidbody2D rbToMove, float speed)
    {
        float remainingDistance = (transform.position -
        _endPosition).sqrMagnitude;
        while (remainingDistance > float.Epsilon)
        {
            if (_targetTransform != null)
            {
                _endPosition = _targetTransform.position;
                if (_endPosition.x > transform.position.x)
                {
                    _anim.SetBool("isFacingEast", true);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                else if (_endPosition.y < transform.position.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", true);
                    _anim.SetBool("isFacingWest", false);
                }
                else if (_endPosition.y > transform.position.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", true);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                else if (_endPosition.x < transform.position.x)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", true);
                }
            }
            if (rbToMove != null)
            {

                Vector3 newPosition = Vector3.MoveTowards(rbToMove.position,
                _endPosition, speed * Time.deltaTime);
                _rb.MovePosition(newPosition);
                if (newPosition.x > transform.position.x)
                {
                    _anim.SetBool("isFacingEast", true);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                else if (newPosition.y < transform.position.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", true);
                    _anim.SetBool("isFacingWest", false);
                }
                else if (newPosition.y > transform.position.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", true);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                else if (newPosition.x < transform.position.x)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", true);
                }
                remainingDistance = (transform.position - _endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision is CapsuleCollider2D &&
        followPlayer)
        {
            _currentSpeed = _pursuitSpeed;
            _targetTransform = collision.gameObject.transform;
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(Move(_rb, _currentSpeed));
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            _currentSpeed = _wanderSpeed;
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _targetTransform = null;
        }
    }
    void OnDrawGizmos()
    {
        if (_circleCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position,
            _circleCollider.radius);
            Debug.DrawLine(_rb.position, _endPosition, Color.red);
        }
    }

    public void ResetPosition()
    {

        transform.position = spawnPoint;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
