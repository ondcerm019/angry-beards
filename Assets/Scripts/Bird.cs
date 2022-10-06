using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 3;

    Vector2 _distance;
    Vector2 _startPosition;
    Rigidbody2D _rigidBody2D;
    SpriteRenderer _spriteRenderer;

    [Range(5,20)]
    public int Force;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidBody2D.position;
        _rigidBody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        _distance = desiredPosition - _startPosition;
        _distance.Normalize();

    }

    private void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
        _rigidBody2D.isKinematic = false;
        _rigidBody2D.AddForce(_distance * _launchForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
