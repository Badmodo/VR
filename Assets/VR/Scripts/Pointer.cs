using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreadandButter.VR
{
    public class Pointer : MonoBehaviour
    {
        private const float TracerWidth = 0.025f;

        public Vector3 EndPoint { get; private set; } = Vector3.zero;
        public bool Active { get; private set; } = false;

        [SerializeField]
        private float cursorScaleFactor = 0.1f;
        public VRController controller;

        [SerializeField]
        private Color invalid = Color.red;
        [SerializeField]
        private Color valid = Color.blue;

        private Transform cursor;
        private Transform tracer;

        private Renderer cursorRender;
        private Renderer tracerRender;

        void Start()
        {
            controller.Input.OnPointerPressed.AddListener(_args =>
            {
                Active = true;
                cursor.gameObject.SetActive(true);
                tracer.gameObject.SetActive(true);
            });

            controller.Input.OnPointerReleased.AddListener(_args =>
            {
                Active = false;
                cursor.gameObject.SetActive(false);
                tracer.gameObject.SetActive(false);
            });

            CreatePointer();
            cursor.gameObject.SetActive(false);
            tracer.gameObject.SetActive(false);
        }

        void Update()
        {
            if (!Active)
            {
                return;
            }

            bool didHit = Physics.Raycast(controller.transform.position, controller.transform.forward, out RaycastHit hit);
            if (didHit)
                DidHit(hit.transform);
            EndPoint = didHit ? hit.point : Vector3.zero;
            UpdateScalePos(hit, didHit);
            SetValid(didHit);
        }

        private void DidHit(Transform _object)
        {
            Target target = _object.GetComponent<Target>();
            if (target != null)
                target.TakeDamage(10.0f * Time.deltaTime);
        }

        public void SetValid(bool _valid)
        {
            cursorRender.material.color = _valid ? valid : invalid; 
            tracerRender.material.color = _valid ? valid : invalid; 
        }

        private void UpdateScalePos(RaycastHit _hit, bool _didHit)
        {
            if (_didHit)
            {
                CalculateDirAndDst(controller.transform.position, _hit.point, out Vector3 dir, out float distance);


                //set the tracer to the midpoint og tht parent and the Endpoint
                Vector3 midPoint = Vector3.Lerp(controller.transform.position, controller.transform.position + _hit.point, 0.5f);
                tracer.position = midPoint;

                //scale the tracer to the endpount and this point
                tracer.localScale = new Vector3(TracerWidth, TracerWidth, distance);

                //ser the cursor to the endpoint and scale it
                cursor.position = controller.transform.position + controller.transform.forward * 100f;
                cursor.localScale = Vector3.one * cursorScaleFactor;
            }
            else
            {
                //set the cursor and the tracer position / scale based on an arbitrary endpoint
                CalculateDirAndDst(controller.transform.position, controller.transform.position + controller.transform.forward * 100, out Vector3 Dir, out float distance);
                Vector3 midPoint = Vector3.Lerp(controller.transform.position, controller.transform.position + Dir * distance, 0.5f);
                tracer.position = midPoint;
                tracer.localScale = new Vector3(TracerWidth, TracerWidth, distance);

                cursor.position = controller.transform.position + controller.transform.forward * 100f;
                cursor.localScale = Vector3.one * cursorScaleFactor;
            }
        }

        private void CalculateDirAndDst(Vector3 _start, Vector3 _end, out Vector3 _dir, out float _distance)
        {
            Vector3 heading = _end - _start;
            _distance = heading.magnitude;
            _dir = heading / _distance;
        }

        private void CreatePointer()
        {
            GameObject tracerObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject cursorObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            tracer = tracerObj.transform;
            cursor = cursorObj.transform;

            Destroy(tracerObj.GetComponent<Collider>());
            Destroy(cursorObj.GetComponent<Collider>());

            tracer.parent = controller.transform;
            cursor.parent = controller.transform;

            tracerRender = tracer.GetComponent<Renderer>();
            cursorRender = cursor.GetComponent<Renderer>();

            SetValid(false);
        }

    }
}