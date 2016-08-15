using UnityEngine;

[RequireComponent(typeof(Duplicatable))]
[RequireComponent(typeof(TapToPlaceOnBoard))]
[RequireComponent(typeof(InteractibleAction))]
public class StickyNote : MonoBehaviour
{
    public string Content
    {
        get
        {
            return _content;
        }
        set
        {
            _content = value;
            SetContentPreview();
        }
    }

    private Duplicatable _duplicatable;
    private TapToPlaceOnBoard _tapToPlaceOnBoard;
    private InteractibleAction _interactibleAction;
    private TextMesh _textMesh;
    private string _content;

    void Start()
    {
        _duplicatable = GetComponent<Duplicatable>();
        _tapToPlaceOnBoard = GetComponent<TapToPlaceOnBoard>();
        _interactibleAction = GetComponent<InteractibleAction>();
        _textMesh = GetComponentInChildren<TextMesh>();
    }

    public void PlaceOnBoard()
    {
        _tapToPlaceOnBoard.OnSelect();
    }

    public void PerformTagAlong()
    {
        if (_tapToPlaceOnBoard.IsPlacingMode() == false)
        {
            _interactibleAction.PerformTagAlong();
        }
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

    private void SetContentPreview()
    {
        var preview = _content.Split(' ')[0];
        if (preview.Length > 5)
        {
            preview = preview.Substring(0, 5);
        }
        _textMesh.text = preview + "...";
    }
}
