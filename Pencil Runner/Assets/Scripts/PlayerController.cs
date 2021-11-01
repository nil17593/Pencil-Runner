using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PencilRunner
{
    public class PlayerController : MonoBehaviour
    {
        #region Components
        private Rigidbody playerRigidbody;
        private Vector3 forwardMov;
        private Vector3 horizontalMov;
        #endregion

        #region Serialized Fields
        [SerializeField] private int speed;
        #endregion

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            ForwardMovement();
            HorizontalMovement();
        }

        private void ForwardMovement()
        {
            forwardMov=Time.fixedDeltaTime * transform.forward;
            playerRigidbody.MovePosition(playerRigidbody.position + forwardMov);
        }

        private void HorizontalMovement()
        {
            if(Input.GetKeyDown (KeyCode.D))
            horizontalMov=speed * Time.fixedDeltaTime * transform.right;
            playerRigidbody.MovePosition(playerRigidbody.position + horizontalMov);

            if (Input.GetKeyDown(KeyCode.A))
            horizontalMov=speed * Time.fixedDeltaTime * -transform.right;
            playerRigidbody.MovePosition(playerRigidbody.position + horizontalMov);
        }
    }
}