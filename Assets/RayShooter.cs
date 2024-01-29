using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;

    // Variable to store the hit point
    private Vector3 hitPoint;
    //public float posHorizontal = 20f;
    //public float posVert = 20f;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 24;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        size = 30;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = size;
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(posX, posY, size, size), "*", style);

        // Display hit coordinates

        
        float posXy = cam.pixelWidth / 1.5f;
        float posYx = cam.pixelHeight / 1.5f;
        
        GUI.Label(new Rect(posXy, posYx, 200, 20), "Hit Point: " + hit.point.ToString());
      // GUI.contentColor = Color.white; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            if (Physics.Raycast(ray, out hit))
            {
                hitPoint = hit.point; // Store the hit point for later use

                Debug.Log("Hit Point Location: " + hitPoint.ToString()); // Log the hit point location

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    Debug.Log("Target hit");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
