using UnityEngine;

public class Lightining : MonoBehaviour
{
    private Camera _cam;
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a point at the middle of the viewport
            Vector3 point = new(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);

            // Create a ray to the created point
            Ray ray = _cam.ScreenPointToRay(point);

            // Data structure to record information about the ray collision
            RaycastHit hit;

            // Check if the created ray collided with any geometry
            if (Physics.Raycast(ray, out hit))
            {
                // Retrieve GameObject ray collided with.
                GameObject hitObj = hit.transform.gameObject;
                ReactiveTarget target = hitObj.GetComponent<ReactiveTarget>();

                //if (target != null)
                    //target.ReactToHit();
            }
        }
    }
}
