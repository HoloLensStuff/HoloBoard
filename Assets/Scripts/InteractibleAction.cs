using Assets.Services;
using HoloToolkit;
using UnityEngine;

public class InteractibleAction : MonoBehaviour
{
    [Tooltip("Drag the Tagalong prefab asset you want to display.")]
    public GameObject ObjectToTagAlong;
    public string Text
    {
        get
        {
            return _note.Content;
        }
    }

    private StickyNote _note;
    private TextMesh _textMesh;
    private BilboardTextFormatterService _bilboardTextParserService;

    void Start()
    {
        _bilboardTextParserService = new BilboardTextFormatterService();
        _note = GetComponent<StickyNote>();
    }

    public void PerformTagAlong()
    {
        if (ObjectToTagAlong == null)
            return;

        var tagAlong = GameObject.FindGameObjectWithTag("TagAlong") ?? CreateTagAlongObject();
        _textMesh = tagAlong.GetComponent<TextMesh>();
        UpdateTagAlongComponent(tagAlong);

        UpdateBilboardText();
    }

    public void SetStickyNoteText(string text)
    {
        if (_note != null)
        {
            _note.Content = text;
        }
    }

    public void UpdateBilboardText()
    {
        _textMesh.text = "";

        if (_textMesh == null || _note.Content == null)
            return;

        _textMesh.text = _bilboardTextParserService.Format(input: _note.Content);
    }

    private GameObject CreateTagAlongObject()
    {
        GameObject item = Instantiate(ObjectToTagAlong);

        item.SetActive(true);
        item.AddComponent<Billboard>();
        item.AddComponent<SimpleTagalong>();

        return item;
    }

    private void UpdateTagAlongComponent(GameObject tagAlong)
    {
        var tagAlongComponent = tagAlong.GetComponent<TagAlong>();
        tagAlongComponent.ObjectToDelete = gameObject;
        tagAlongComponent.Interactable = this;
    }
}