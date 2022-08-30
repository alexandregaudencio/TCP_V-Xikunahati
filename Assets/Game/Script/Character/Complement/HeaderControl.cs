using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace head
{
    public enum HEAD_ROTATION { action, Idle };
    public class HeaderControl : MonoBehaviour
    {
        public HEAD_ROTATION header = HEAD_ROTATION.Idle;
        public bool dive;
        public GameObject forehead;
        public Vector3 idlePosition;
        public Vector3 divePosition;
        public Vector3 diveHeadPosition;
        public float diveHeadRotationQuaternionX;

        private void Start()
        {
            this.dive = false;

            this.transform.localRotation = Quaternion.Euler(transform.right * -25);
            this.forehead.transform.rotation = Quaternion.Euler(transform.right * 45); 
       
            if (this.forehead.GetComponent<Rigidbody>())
            {
                this.forehead.GetComponent<Rigidbody>().isKinematic = true;
                this.forehead.GetComponent<Rigidbody>().useGravity = false;
            }

            this.forehead.tag = "Head";
            this.forehead.transform.SetParent(gameObject.transform);
            this.forehead.transform.localPosition = new Vector3(0, .7f, 1);

        }
        private void Reset()
        {
            this.forehead = new GameObject("forehead");
            this.forehead.AddComponent<Rigidbody>();
            this.forehead.layer = LayerMask.NameToLayer("Head");
            this.forehead.GetComponent<Rigidbody>().isKinematic = true;
            this.forehead.GetComponent<Rigidbody>().useGravity = false;
            this.forehead.transform.SetParent(gameObject.transform);
            this.forehead.transform.localPosition = new Vector3(0, .7f, 1);
        }
        void Update()
        {
            switch (header)
            {
                case HEAD_ROTATION.action:
                    ToAction();
                    break;
                case HEAD_ROTATION.Idle:
                    GoToIdle();
                    break;
            }
        }
        private void ToAction()
        {
            if (dive)
            {
                forehead.transform.localPosition = diveHeadPosition;
                this.transform.localRotation = Quaternion.Euler(diveHeadRotationQuaternionX, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(30, 0, 0);
            }
            else
            {
                forehead.transform.localPosition = idlePosition;

                this.transform.localRotation = Quaternion.Euler(-25, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(80, 0, 0);

            }
        }
        private void GoToIdle()
        {
            if (dive)
            {
                forehead.transform.localPosition = divePosition;
                this.transform.localRotation = Quaternion.Euler(20, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(40, 0, 0);
            }
            else
            {
                forehead.transform.localPosition = idlePosition;
                this.transform.localRotation = Quaternion.Euler(-25, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(45, 0, 0);
            }
        }

    }

}
