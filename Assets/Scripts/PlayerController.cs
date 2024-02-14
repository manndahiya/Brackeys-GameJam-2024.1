using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float RotSpeed = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float speedX;
    [SerializeField] float speedY;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        PlayerRotate();
        PlayerMove();
    }

    private void PlayerMove()
    {
       
        speedX = Input.GetAxis("Horizontal") * moveSpeed;
        speedY = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(speedX, speedY);

    }

    private void PlayerRotate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = worldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotSpeed * Time.deltaTime);
    }
}
