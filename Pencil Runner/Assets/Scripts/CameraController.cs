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

        public bool reached = false;

        private static CameraController cameraInstance;
        public static CameraController CameraInstance { get { return cameraInstance; } }

        private void Awake()
        {
            cameraInstance = this;
        }

        private void Start()
        {
            reached = false;
        }

        public void FollowPlayer()
        {
            if (target!=null || reached==false)
            {
                targetPos = target.position + offset;
                smoothPos = Vector3.Lerp(transform.position.normalized, targetPos, smoothFactor * Time.deltaTime);
                transform.position = targetPos;
            }
        }

        private void LateUpdate()
        {
            FollowPlayer();
            //CameraPosiAfterLevelComplete();
        }

        public void CameraPosiAfterLevelComplete()
        {
            reached = true;
            //targetPos = new Vector3(0,3f,180f);
            //transform.position.x = 0f;
            Vector3 newPos = transform.position;
    
            newPos.x = 0f;
            Debug.Log(newPos);
            //transform.position = newPos;
            transform.eulerAngles = new Vector3(50f, 0f, 0f);
            transform.position = newPos;
            //smoothPos = Vector3.Lerp(transform.position.normalized, targetPos, smoothFactor * Time.deltaTime);
            //transform.position = targetPos;
        }
    }

}