using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace BreadandButter.VR.Interaction
{
    [RequireComponent(typeof(Rigidbody))]
    public class InteractableObject : MonoBehaviour
    {
        public Rigidbody Rigidbody => rigibody;
        public Collider Collider => collider;
        public Transform AttachPoint => attachPoint;


        [SerializeField] private bool isGrabbable = true;
        [SerializeField] private bool isTouchable = true;
        [SerializeField] private bool isUsable = false;
        [SerializeField] private SteamVR_Input_Sources allowedSource = SteamVR_Input_Sources.Any;

        [Space]

        [SerializeField, Tooltip("")] private Transform attachPoint;

        [Space]

        public InteractionEvent onGrabbed = new InteractionEvent();
        public InteractionEvent onReleased = new InteractionEvent();
        public InteractionEvent onTouched = new InteractionEvent();
        public InteractionEvent onStopTouching = new InteractionEvent();
        public InteractionEvent onUsed = new InteractionEvent();
        public InteractionEvent onStopUsing = new InteractionEvent();

        private new Collider collider;
        private new Rigidbody rigibody;

        void Start()
        {
            collider = gameObject.GetComponent<Collider>();
            if(collider == null)
            {
                collider = gameObject.AddComponent<BoxCollider>();
                Debug.LogError($"Object {name} does not have a collider, adding BoxCollider", gameObject);
            }
            rigibody = gameObject.GetComponent<Rigidbody>();
        }

        private InteractEventArgs GenerateArgs(VRController _controller)
            => new InteractEventArgs(_controller, rigibody, collider);

        public void OnObjectGrabbed(VRController _controller)
        {
            if(isGrabbable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
            {
                onGrabbed.Invoke(GenerateArgs(_controller));
            }
        }

        public void OnObjectReleased(VRController _controller)
        {
            if(isGrabbable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
            {
                onGrabbed.Invoke(GenerateArgs(_controller));
            }
        }
        
        public void OnObjectTouched(VRController _controller)
        {
            if(isTouchable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
            {
                onGrabbed.Invoke(GenerateArgs(_controller));
            }
        }

        public void OnObjectStopTouching(VRController _controller)
        {
            if(isTouchable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
            {
                onGrabbed.Invoke(GenerateArgs(_controller));
            }
        }
        
        public void OnObjectUsed(VRController _controller)
        {
            if(isUsable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
            {
                onGrabbed.Invoke(GenerateArgs(_controller));
            }
        }  
        
        public void OnObjectStopUsing(VRController _controller)
        {
            if(isUsable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
            {
                onGrabbed.Invoke(GenerateArgs(_controller));
            }
        }
    }
}