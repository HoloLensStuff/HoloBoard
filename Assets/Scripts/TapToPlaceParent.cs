using UnityEngine;

public class TapToPlaceParent : MonoBehaviour
{
    bool placing = false;
    Renderer rend;
    Shader shader1;
    Shader shader2;

    void Start()
    {
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Custom/StickyNoteSelected");
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        // If the user is in placing mode, display the spatial mapping mesh.
        if (placing)
        {
            //SpatialMapping.Instance.DrawVisualMeshes = true;
            rend.material.shader = shader2;
        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {
            //SpatialMapping.Instance.DrawVisualMeshes = false;
            rend.material.shader = shader1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            int whiteBoardLayer = 1 << 8;
            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, whiteBoardLayer))
            {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.
                this.transform.parent.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.parent.rotation = toQuat;
            }
        }
    }
}
