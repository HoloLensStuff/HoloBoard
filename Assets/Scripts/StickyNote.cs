using UnityEngine;

[RequireComponent(typeof(DuplicateManager))]
[RequireComponent(typeof(TapToPlaceOnBoard))]
[RequireComponent(typeof(InteractibleAction))]
public class StickyNote : MonoBehaviour
{
    private string _content;
    public string Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
            _interactibleAction.SetText(_content);
        }
    }

    DuplicateManager _duplicateManager;
    TapToPlaceOnBoard _tapToPlaceOnBoard;
    InteractibleAction _interactibleAction;

    void Start()
    {
        _duplicateManager = GetComponent<DuplicateManager>();
        _tapToPlaceOnBoard = GetComponent<TapToPlaceOnBoard>();
        _interactibleAction = GetComponent<InteractibleAction>();

        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
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
