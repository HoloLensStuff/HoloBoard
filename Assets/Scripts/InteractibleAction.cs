using Assets.Services;
using HoloToolkit;
using UnityEngine;
using UnityEngine.UI;

public class InteractibleAction : MonoBehaviour
{
    [Tooltip("Drag the Tagalong prefab asset you want to display.")]
    public GameObject ObjectToTagAlong;
    public string Text { get { return _text; } }

    private string _text;
    private TextMesh _textMesh;
    private BilboardTextFormatterService _bilboardTextParserService;

    void Start()
    {
        _bilboardTextParserService = new BilboardTextFormatterService();
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
        _text = text;

        var stickyNote = GetComponent<StickyNote>();
        if (stickyNote != null)
            stickyNote.Content = text;
    }

    public void UpdateBilboardText()
    {
        _textMesh.text = "";

        if (_textMesh == null
            || _text == null)
            return;

        _textMesh.text = _bilboardTextParserService.Format(_text);
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