using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal = 10f;
    [SerializeField] float moveSpeedVertical = 20f;
    float horizontalValue;

    private float xMin = -3.6f;
    private float xMax =  3.6f;

    void Update()
    {
        HorizontalValue();
    }

    void FixedUpdate()
    {
        MovementController();
    }

    void HorizontalValue()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }

    void MovementController()
    {
        float xPos = horizontalValue * moveSpeedHorizontal * Time.fixedDeltaTime;
        float yPos = moveSpeedVertical * Time.fixedDeltaTime;
        transform.Translate(xPos, -yPos, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), 
                                                transform.position.y, transform.position.z);
    }  
}
