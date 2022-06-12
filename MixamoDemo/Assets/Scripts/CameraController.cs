using UnityEngine;

namespace Murder.Character
{
    public class CameraController : MonoBehaviour
    {

        public GameObject targetObject;

        private Vector3 offset;      

        // Use this for initialization
        void Start()
        {
            offset = transform.position - targetObject.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = targetObject.transform.position + offset;
        }
    }
}
