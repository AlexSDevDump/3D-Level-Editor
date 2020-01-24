using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }


    private Vector3 horMoveDir;
    public float moveSpeed;

    public float rotSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        horMoveDir = new Vector3(Input.GetAxis("X"), 0, Input.GetAxis("Z"));
        horMoveDir *= moveSpeed * Time.deltaTime;
        transform.Translate(horMoveDir.x, 0, horMoveDir.z);
        transform.Translate(0, Input.GetAxis("Y") * moveSpeed * Time.deltaTime, 0, Space.World);
    }

    public void Look()
    {
        if (Input.GetAxisRaw("Rotation Lock") == 1)
        {
            HideCursor();
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
            transform.eulerAngles = new Vector2(rotation.x, rotation.y) * rotSpeed;
        }
        else
        {
            ShowCursor();
        }
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None; //Weird bug where transitioning from locked to confined doesn't work
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
