using UnityEngine;

[RequireComponent(typeof(DuplicateManager))]
[RequireComponent(typeof(TapToPlaceOnBoard))]
public class StickyNote : MonoBehaviour
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
        if (_tapToPlaceOnBoard.IsPlacingMode() == false)
        {
            _duplicateManager.Duplicate();
        }
    }
    public void PlaceOnBoard()
    {
        _tapToPlaceOnBoard.OnSelect();
    }
}
