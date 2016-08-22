using UnityEngine;

public class BillboardEdit : MonoBehaviour
{
    private TouchScreenKeyboard _keyboard;
    private TagAlong _tagAlong;

    void Update()
    {
        if (TouchScreenKeyboard.visible == false && IsKeyboardClosed())
        {
            var wasCanceled = _keyboard.wasCanceled;
            var keyboardText = _keyboard.text;

            _keyboard = null;
            if (wasCanceled)
                return;

            _tagAlong.Interactable.Text = keyboardText;
            _tagAlong.Interactable.UpdateBilboardText();
        }
    }

    public void OnSelect()
    {
        _tagAlong = FindObjectOfType<TagAlong>();
        if (_tagAlong == null)
            return;

        OpenKeyboard();
    }

    private bool IsKeyboardClosed()
    {
        return _keyboard != null && _keyboard.active == false && _keyboard.done == true;
    }

    private void OpenKeyboard()
    {
        _keyboard = TouchScreenKeyboard.Open(_tagAlong.Interactable.Text ?? "", TouchScreenKeyboardType.Default, false, false, false, false, "Edit content");
    }
}
