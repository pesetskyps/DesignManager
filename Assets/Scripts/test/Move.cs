using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.y = 0;

        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
    }
}
