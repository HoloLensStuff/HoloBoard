using Assets.Services;
using HoloToolkit;
using UnityEngine;

/// <summary>
/// InteractibleAction performs custom actions when you gaze at the holograms.
/// </summary>
public class InteractibleAction : MonoBehaviour
{
    [Tooltip("Drag the Tagalong prefab asset you want to display.")]
    public GameObject ObjectToTagAlong;

    private string _text;
    private BilboardTextFormatterService _bilboardTextParserService;

    void Start()
    {
        _bilboardTextParserService = new BilboardTextFormatterService();
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public void PerformTagAlong()
    {
        if (ObjectToTagAlong == null)
            return;

        GameObject existingTagAlong = GameObject.FindGameObjectWithTag("TagAlong");
        if (existingTagAlong != null)
            return;

        CreateTagAlongObject();
    }
    #region PerformTagAlong private functions
    private void CreateTagAlongObject()
    {
        GameObject item = GameObject.Instantiate(ObjectToTagAlong);

        item.SetActive(true);
        item.AddComponent<Billboard>();
        item.AddComponent<SimpleTagalong>();

        var textMesh = item.AddComponent<TextMesh>();
        ConfigureTextMesh(textMesh);
    }
    private void ConfigureTextMesh(TextMesh textMesh)
    {
        textMesh.text = _bilboardTextParserService.Format(_text);
        textMesh.offsetZ = -0.05f;
        textMesh.characterSize = 0.015f;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.color = new Color(0f, 255f, 0f, 255f);
    }
    #endregion
}