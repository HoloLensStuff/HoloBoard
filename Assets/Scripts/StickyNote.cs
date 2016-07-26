using UnityEngine;

[RequireComponent(typeof(DuplicateManager))]
[RequireComponent(typeof(TapToPlaceOnBoard))]
[RequireComponent(typeof(InteractibleAction))]
public class StickyNote : MonoBehaviour
{
    DuplicateManager _duplicateManager;
    TapToPlaceOnBoard _tapToPlaceOnBoard;
    InteractibleAction _interactibleAction;

    void Start()
    {
        _duplicateManager = GetComponent<DuplicateManager>();
        _tapToPlaceOnBoard = GetComponent<TapToPlaceOnBoard>();
        _interactibleAction = GetComponent<InteractibleAction>();
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
    public void PerformTagAlong()
    {
        _interactibleAction.PerformTagAlong();
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
