using Assets.Services;
using HoloToolkit;
using UnityEngine;
using UnityEngine.UI;

public class InteractibleAction : MonoBehaviour
{
    [Tooltip("Drag the Tagalong prefab asset you want to display.")]
    public GameObject ObjectToTagAlong;

    private string _text;
    private TextMesh _textMesh;
    private BilboardTextFormatterService _bilboardTextParserService;
    private TouchScreenKeyboard keyboard;

    void Start()
    {
        _bilboardTextParserService = new BilboardTextFormatterService();
    }

    void Update()
    {
        if (IsKeyboardClosed())
        {
            var wasCanceled = keyboard.wasCanceled;
            var keyboardText = keyboard.text;

            keyboard = null;
            if (wasCanceled)
                return;

            SetStickyNoteText(keyboardText);

            UpdateBilboardText();
        }
    }

    public void PerformTagAlong()
    {
        if (ObjectToTagAlong == null)
            return;

        var tagAlong = GameObject.FindGameObjectWithTag("TagAlong") ?? CreateTagAlongObject();
        _textMesh = tagAlong.GetComponent<TextMesh>();
        UpdateBilboardText();

        OpenKeyboard();
    }

    private GameObject CreateTagAlongObject()
    {
        GameObject item = Instantiate(ObjectToTagAlong);

        item.SetActive(true);
        item.AddComponent<Billboard>();
        item.AddComponent<SimpleTagalong>();

        var tagAlong = item.GetComponent<TagAlong>();
        tagAlong.ObjectToDelete = gameObject;

        return item;
    }

    private void SetStickyNoteText(string text)
    {
        _text = text;

        var stickyNote = GetComponent<StickyNote>();
        if (stickyNote != null)
            stickyNote.Content = text;
    }

    private void UpdateBilboardText()
    {
        if (_textMesh == null
            || _text == null)
            return;

        _textMesh.text = _bilboardTextParserService.Format(_text);
    }

    private bool IsKeyboardClosed()
    {
        return keyboard != null && keyboard.active == false && keyboard.done == true;
    }

    private void OpenKeyboard()
    {
        keyboard = new TouchScreenKeyboard(_text, TouchScreenKeyboardType.Default, false, false, false, false, "Edit content");
    }
}