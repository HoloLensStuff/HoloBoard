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

    private bool _isDuplicatable = true;
    private Duplicatable _duplicatable;
    private TapToPlaceOnBoard _tapToPlaceOnBoard;
    private InteractibleAction _interactibleAction;
    private TextMesh _textMesh;
    private string _content;
    private const int LINE_BUFFER = 5;

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
        if (_isDuplicatable)
        {
            _isDuplicatable = false;
            _duplicatable.Duplicate();
        }
    }

    private void SetContentPreview()
    {
        var preview = _content.Trim();
        if (_content.Length > LINE_BUFFER)
        {
            preview = preview.Split(' ')[0];
            if (preview.Length > LINE_BUFFER)
            {
                preview = preview.Substring(0, LINE_BUFFER);
            }
            preview = preview + "...";
        }
        _textMesh.text = preview;
    }
}
