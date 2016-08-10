using UnityEngine;

public class TapToPlaceOnBoard : MonoBehaviour
{
    public Material defaultMaterial;
    public Material activeObjectMaterial;

    private Renderer currentRenderer;
    private bool placing = false;
    private const float MAX_DISTANCE = 30.0f;
    private const int WHITE_BOARD_LAYER = 1 << 8;

    void Start()
    {
        currentRenderer = GetComponent<Renderer>();
    }

    public bool IsPlacingMode() { return placing; }

    void Update()
    {
        if (placing)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(GetHeadPosition(), GetGazeDirection(),
                out hitInfo,
                MAX_DISTANCE, WHITE_BOARD_LAYER))
            {
                this.transform.position = hitInfo.point;                                
                this.transform.rotation = GetLocalRotationY();
            }
        }
    }    
    private static Vector3 GetHeadPosition()
    {
        return Camera.main.transform.position;
    }
    private static Vector3 GetGazeDirection()
    {
        return Camera.main.transform.forward;
    }
    private static Quaternion GetLocalRotationY()
    {
        Quaternion result = Camera.main.transform.localRotation;

        result.x = 0;
        result.z = 0;

        return result;
    }

    public void OnSelect()
    {
        placing = !placing;

        SetRendererMaterial();
    }
    private void SetRendererMaterial()
    {
        currentRenderer.material = placing ? activeObjectMaterial : defaultMaterial;
    }
}
