﻿using UnityEngine;

namespace HoloToolkit
{
    public enum PivotAxis
    {
        // Rotate about all axes.
        Free,
        // Rotate about an individual axis.
        X,
        Y
    }

    /// <summary>
    /// The Billboard class implements the behaviors needed to keep a GameObject 
    /// oriented towards the user.
    /// </summary>
    public class Billboard : MonoBehaviour
    {
        /// <summary>
        /// The axis about which the object will rotate.
        /// </summary>
        [Tooltip("Specifies the axis about which the object will rotate (Free rotates about both X and Y).")]
        public PivotAxis PivotAxis = PivotAxis.Free;

        /// <summary>
        /// Overrides the cached value of the GameObject's default rotation.
        /// </summary>
        public Quaternion DefaultRotation { get; private set; }

        private void Awake()
        {
            // Cache the GameObject's default rotation.
            DefaultRotation = gameObject.transform.rotation;
        }

        /// <summary>
        /// The billboard logic is performed in FixedUpdate to update the object
        /// with the player independent of the frame rate.  This allows the object to 
        /// remain correctly rotated even if the frame rate drops.
        /// </summary>
        private void FixedUpdate()
        {
            // Get a Vector that points from the Camera to the Target.
            Vector3 directionToTarget = Camera.main.transform.position - gameObject.transform.position;

            // Adjust for the pivot axis.
            switch (PivotAxis)
            {
                case PivotAxis.X:
                    directionToTarget.x = gameObject.transform.position.x;
                    break;

                case PivotAxis.Y:
                    directionToTarget.y = gameObject.transform.position.y;
                    break;

                case PivotAxis.Free:
                default:
                    // No changes needed.
                    break;
            }

            // Calculate and apply the rotation required to reorient the object and apply the default rotation to the result.
            gameObject.transform.rotation = Quaternion.LookRotation(-directionToTarget) * DefaultRotation;
        }
    }
}