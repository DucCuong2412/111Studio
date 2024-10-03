using UnityEngine;

public class MoveBetweenTwoObjects : MonoBehaviour
{
    public GameObject pointA; // Đối tượng làm điểm A
    public GameObject pointB; // Đối tượng làm điểm B
    public float speed = 2.0f; // Tốc độ di chuyển

    private bool movingToB = true; // Để theo dõi hướng di chuyển

    void Update()
    {
        // Kiểm tra hướng di chuyển
        if (movingToB)
        {
            // Di chuyển về phía điểm B
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, speed * Time.deltaTime);

            // Khi đối tượng đến gần điểm B, đổi hướng
            if (Vector3.Distance(transform.position, pointB.transform.position) < 0.1f)
            {
                movingToB = false;
            }
        }
        else
        {
            // Di chuyển về phía điểm A
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);

            // Khi đối tượng đến gần điểm A, đổi hướng
            if (Vector3.Distance(transform.position, pointA.transform.position) < 0.1f)
            {
                movingToB = true;
            }
        }
    }
}
