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
        [SerializeField] private float forwardMovSpeed;
        [SerializeField] private float horizontalMovSpeed;
        [SerializeField] private float increaseSize;
        [SerializeField] private int score;
        //[SerializeField] private float decreasSize;
        //[SerializeField] private float fixedSize;
        #endregion

        #region Private Integers
        private int laneNumber;
        #endregion

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            ForwardMovement();
            HorizontalMovement();
            //ReduceSize();
            Die();
        }

        private void ForwardMovement()
        {
            forwardMov= forwardMovSpeed * Time.fixedDeltaTime * transform.forward;
            playerRigidbody.MovePosition(playerRigidbody.position + forwardMov);
        }

        private void HorizontalMovement()
        {
            if (Input.GetKey(KeyCode.D) || SwipeManager.swipeRight)
            {
                horizontalMov = horizontalMovSpeed * Time.fixedDeltaTime * transform.right;
                playerRigidbody.MovePosition(playerRigidbody.position + horizontalMov);
                laneNumber++;
                if (laneNumber == 3)
                {
                    laneNumber = 2;
                }
            }

            if (Input.GetKey(KeyCode.A) || SwipeManager.swipeLeft)
            {
                horizontalMov = horizontalMovSpeed * Time.fixedDeltaTime * -transform.right;
                playerRigidbody.MovePosition(playerRigidbody.position + horizontalMov);
                laneNumber--;
                if (laneNumber == -1)
                {
                    laneNumber = 0;
                }
            }
        }

        //private void ReduceSize()
        //{
        //    if(fixedSize==1)
        //    transform.localScale += new Vector3(0f, -0.4f* Time.deltaTime,0f);
        //}

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Gainer"))
            {
                Destroy(other.gameObject);

                gameObject.transform.localScale = new Vector3(0.3f, increaseSize+=1f, 0.2f);
                //gameObject.transform.localScale.y += increaseSize;
            }
            if (other.CompareTag("Reducer"))
            {
                if (increaseSize != 1f)
                    gameObject.transform.localScale = new Vector3(0.2f, increaseSize-=1f, 0.2f);
                Debug.Log(other.name);
                    //float temp = transform.localScale.y;
                //gameObject.transform.localScale = new Vector3(0.2f, gameObject.transform.localScale.y-=1f, 0.2f);
            }
            if (other.CompareTag("Gems"))
            {
                Destroy(other.gameObject);
                Debug.Log(other.name);
                UIManager.Instance.IncreaseScore(score);
            }
            if (other.CompareTag("Endline"))
            {
                //CameraController.CameraInstance.CameraPosiAfterLevelComplete();
                //if(UIManager.Instance)
            }
        }

        private void Die()
        {
            if (this.transform.position.y < -3)
            {
                gameObject.SetActive(false);
                UIManager.Instance.LoadGameoverPanel();
            }
        }
    }
}