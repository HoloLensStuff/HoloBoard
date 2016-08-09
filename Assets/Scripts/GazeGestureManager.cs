using System;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // Use this for initialization
    void Start()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += Recognizer_TappedEvent;

        recognizer.StartCapturingGestures();
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        HandleStickyNoteTap();
        HandleDismissOnSelect();
        HandleBillboardDelete();
        HandleBillboardEdit();
    }
    #region Recognizer_TappedEvent private methods
    private void HandleDismissOnSelect()
    {
        DismissOnSelect dismissableObject = FocusedObject.GetComponent<DismissOnSelect>();
        if (dismissableObject != null)
        {
            dismissableObject.OnSelect();
        }
    }
    private void HandleStickyNoteTap()
    {
        StickyNote focusedStickyNote = FocusedObject.GetComponent<StickyNote>();
        if (focusedStickyNote != null)
        {
            focusedStickyNote.PerformTagAlong();
            focusedStickyNote.Duplicate();
            focusedStickyNote.PlaceOnBoard();
        }
    }    
    private void HandleBillboardDelete()
    {
        BillboardDelete billboardDelete = FocusedObject.GetComponent<BillboardDelete>();
        if (billboardDelete != null)
        {
            billboardDelete.Delete();
        }
    }
    private void HandleBillboardEdit()
    {
        BillboardEdit billboardEdit = FocusedObject.GetComponent<BillboardEdit>();
        if (billboardEdit != null)
        {
            billboardEdit.OnSelect();
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        GameObject oldFocusObject = FocusedObject;
        
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
