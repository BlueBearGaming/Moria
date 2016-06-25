using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
    public class LockedLookCam : PivotBasedCameraRig
    {
        // This script is designed to be placed on the root object of a camera rig,
        // comprising 3 gameobjects, each parented to the next:

        // 	Camera Rig
        // 		Pivot
        // 			Camera

        [SerializeField] private float m_MoveSpeed = 2f;                      // How fast the rig will move to keep up with the target's position.
        [SerializeField] private bool m_LockCursor = false;                   // Whether the cursor should be hidden and locked.

        protected override void Awake()
        {
            base.Awake();
            // Lock or unlock the cursor.
            Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
			Cursor.visible = !m_LockCursor;
        }


        protected void Update()
        {
            if (m_LockCursor && Input.GetMouseButtonUp(0))
            {
                Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = !m_LockCursor;
			}
			m_Pivot.rotation = Quaternion.Euler(60, 45, 0);
			m_Cam.localRotation = Quaternion.Euler(0, 0, 0);
        }


        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        protected override void FollowTarget(float deltaTime)
        {
            if (m_Target == null) return;
            // Move the rig towards target position.
            transform.position = Vector3.Lerp(transform.position, m_Target.position, deltaTime*m_MoveSpeed);
        }
    }
}
