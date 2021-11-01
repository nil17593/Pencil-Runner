using System.Collections;
using UnityEngine;

namespace PencilRunner
{
    public class CameraController : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothFactor;
        #endregion

        #region Components
        private Vector3 targetPos;
        private Vector3 smoothPos;
        #endregion

        private void FollowPlayer()
        {
            if (target != null)
            {
                targetPos = target.position + offset;
                smoothPos = Vector3.Lerp(transform.position.normalized, targetPos, smoothFactor * Time.deltaTime);
                transform.position = targetPos;
            }
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }
    }

}