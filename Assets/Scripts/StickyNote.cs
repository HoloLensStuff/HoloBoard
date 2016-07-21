using UnityEngine;

[RequireComponent(typeof(DuplicateManager))]
[RequireComponent(typeof(TapToPlaceParent))]
public class StickyNote : MonoBehaviour
{
    DuplicateManager _duplicateManager;
    TapToPlaceParent _tapToPlaceParent;

    void Start()
    {
        _duplicateManager = GetComponent<DuplicateManager>();
        _tapToPlaceParent = GetComponent<TapToPlaceParent>();
    }

    public void Duplicate()
    {
        _duplicateManager.Duplicate();
    }
    public void PlaceParent()
    {
        _tapToPlaceParent.OnSelect();
    }
}
