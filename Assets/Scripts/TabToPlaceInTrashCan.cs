using UnityEngine;
using System.Collections;

public class TabToPlaceInTrashCan : MonoBehaviour {

    public Material defaultMaterial;
    public Material activeObjectMaterial;

    Renderer currentRenderer;
    bool placing = false;

    void Start()
    {
        currentRenderer = GetComponent<Renderer>();
    }

    public bool IsPlacingMode() { return placing; }

    // Called by GazeGestureManager when the user performs a Select gesture
    public void OnSelect()
    {
        placing = !placing;

        currentRenderer.material = placing ? activeObjectMaterial : defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (placing)
        {
            int trasCanLayer = 1 << 9;

            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, trasCanLayer))
            {
                this.transform.position = hitInfo.point;

                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.rotation = toQuat;
            }
        }
    }
}
