using UnityEngine;

[RequireComponent(typeof(Duplicatable))]
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

    Duplicatable _duplicatable;
    TapToPlaceOnBoard _tapToPlaceOnBoard;
    InteractibleAction _interactibleAction;

    void Start()
    {
        _duplicatable = GetComponent<Duplicatable>();
        _tapToPlaceOnBoard = GetComponent<TapToPlaceOnBoard>();
        _interactibleAction = GetComponent<InteractibleAction>();

        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
    }

    public void PlaceOnBoard()
    {
        _tapToPlaceOnBoard.OnSelect();
    }
    public void PerformTagAlong()
    {
        _interactibleAction.PerformTagAlong();
    }
    public void Duplicate()
    {
        if (CanDuplicate())
            _duplicatable.Duplicate();
    }

    private bool CanDuplicate()
    {
        return (_tapToPlaceOnBoard.IsPlacingMode() || WasMoved()) == false;

    }
    private bool WasMoved()
    {
        return gameObject.transform.localPosition.Equals(new Vector3(0, 0, 0)) == false;
    }
}
