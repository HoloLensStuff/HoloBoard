using UnityEngine;

[RequireComponent(typeof(DuplicateManager))]
[RequireComponent(typeof(TapToPlaceOnBoard))]
public class PinkStickyNote : MonoBehaviour
{
    DuplicateManager _duplicateManager;
    TapToPlaceOnBoard _tapToPlaceOnBoard;

    void Start()
    {
        _duplicateManager = GetComponent<DuplicateManager>();
        _tapToPlaceOnBoard = GetComponent<TapToPlaceOnBoard>();
    }

    public void Duplicate()
    {
        if (CanDuplicate())
        {
            _duplicateManager.Duplicate();
        }
    }
    public void PlaceOnBoard()
    {
        _tapToPlaceOnBoard.OnSelect();
    }

    private bool CanDuplicate()
    {
        if (_tapToPlaceOnBoard.IsPlacingMode()
            || WasMoved())
        {
            return false;
        }

        return true;
    }
    private bool WasMoved()
    {
        return gameObject.transform.localPosition.Equals(new Vector3(0, 0, 0)) == false;
    }
}
