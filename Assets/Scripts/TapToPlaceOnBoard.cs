using UnityEngine;

public class TapToPlaceOnBoard : MonoBehaviour
{
    public Material DefaultMaterial;
    public Material ActiveObjectMaterial;

    private const float MAX_DISTANCE = 30.0f;
    private const int WHITE_BOARD_LAYER = 1 << 8;

    private Renderer _currentRenderer;
    private bool _placing = false;

    public bool IsPlacingMode() { return _placing; }

    void Start()
    {
        _currentRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (_placing)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(GetHeadPosition(), GetGazeDirection(),
                out hitInfo,
                MAX_DISTANCE, WHITE_BOARD_LAYER))
            {
                transform.position = hitInfo.point;
                //transform.rotation = GetLocalRotationY();
            }
        }
    }

    public void OnSelect()
    {
        // reset the rotation when placing on the board
        if (_placing)
        {
            //ResetRotation();
        }

        _placing = !_placing;

        SetRendererMaterial();
    }

    private void SetRendererMaterial()
    {
        _currentRenderer.material = _placing ? ActiveObjectMaterial : DefaultMaterial;
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
        result.y = 0;
        result.z = 0;

        return result;
    }

    private void ResetRotation()
    {
        Quaternion rotation = new Quaternion();
        transform.rotation = rotation;
    }
}
