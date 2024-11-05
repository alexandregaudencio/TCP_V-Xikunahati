//using UnityEngine;

//namespace Ball
//{
//    public class Prediction : MonoBehaviour
//    {
//        public GameObject feedback;

//        private BallController ballController;
//        private Rigidbody Rigidbody;
//        private Bounce bounce;



//        public void SetPositionFeedback(GameObject target)
//        {
//            this.feedback = GameObject.CreatePrimitive(PrimitiveType.Quad);
//            this.feedback.GetComponent<MeshCollider>().enabled = false;
//            this.feedback.transform.SetParent(target.transform);
//            this.feedback.name = "feedback";
//            this.feedback.transform.localScale = new Vector3(5.5f, 5.5f, 0);
//            this.feedback.transform.rotation = Quaternion.Euler(90, 0, 0);
//            this.feedback.transform.localPosition = new Vector3(0, 0.8f, 0);
//            Material mat = target.GetComponent<MeshRenderer>().material;
//            this.feedback.GetComponent<MeshRenderer>().material = mat;
//        }



//    }


//}