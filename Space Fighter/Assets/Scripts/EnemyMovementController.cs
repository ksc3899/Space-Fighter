using UnityEngine;

[System.Serializable]
public class DestroyBoundary
{
    public float bottom, top, left, right;
}

public class EnemyMovementController : MonoBehaviour
{
    public DestroyBoundary boundaryLimits;
    public float speed;

    private Vector3 direction;
    private Transform playerPosition;
    
    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
       if ( boundaryLimits.top < this.transform.position.y ||
            boundaryLimits.bottom > this.transform.position.y ||
            boundaryLimits.left > this.transform.position.x ||
            boundaryLimits.right < this.transform.position.x )
        {
            Destroy(this.gameObject);
        }
    }

    public void Move(int n)
    {
        switch (n)
        {
            case 0:
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(1f, 0f, 0f) * speed;
                    break;
                }
            case 1:
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -1f, 0f) * speed;
                    break;
                }
            case 2:
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, 0f, 0f) * speed;
                    break;
                }
            case 3:
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 1f, 0f) * speed;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
