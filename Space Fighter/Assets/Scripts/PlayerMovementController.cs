using UnityEngine;

[System.Serializable]
public class BoundaryLimits
{
    public float xMax, xMin, yMax, yMin;
}

public class PlayerMovementController : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float boostSpeed;
    public float breakdownSpeed;
    public float defaultTurnSpeed;
    public BoundaryLimits boundaryLimits;
    //public float maximumDefaultMovementSpeed;
    //public float maximumBoostSpeed;
    //public float maximumBreakdownSpeed;

    private float timer = 0f;

    private void Update()
    {
        this.transform.position = new Vector3(
                                               Mathf.Clamp(transform.position.x, boundaryLimits.xMin, boundaryLimits.xMax),
                                               Mathf.Clamp(transform.position.y, boundaryLimits.yMin, boundaryLimits.yMax),
                                               0f
                                             );

        timer += Time.deltaTime;
        if (timer >= 30f && timer <= 40f)
        {
            defaultMovementSpeed += 0.5f;
            boostSpeed += 0.5f;
            breakdownSpeed += 0.5f;
        }
    }

    private void FixedUpdate()
    {
        //MOVEMENT
        float movementSpeed = defaultMovementSpeed;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementSpeed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementSpeed = breakdownSpeed;
        }
        this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

        //ROTATION
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 newRotation = new Vector3(0f, 0f, defaultTurnSpeed * Time.deltaTime);
            transform.Rotate(newRotation);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 newRotation = new Vector3(0f, 0f, -defaultTurnSpeed * Time.deltaTime);
            transform.Rotate(newRotation);
        }
    }
}
