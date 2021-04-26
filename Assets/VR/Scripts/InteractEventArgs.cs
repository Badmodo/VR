using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Serializable = System.SerializableAttribute;

namespace BreadandButter.VR.Interaction
{
    [Serializable]
    public class InteractionEvent : UnityEvent<InteractEventArgs> { }

    [Serializable]
    public class InteractEventArgs : MonoBehaviour
    {
        public VRController controller;

        public Rigidbody rigidbody;

        public Collider collider;

        public InteractEventArgs(VRController _controller, Rigidbody _rigidbody, Collider _collider)
        {
            controller = _controller;
            rigidbody = _rigidbody;
            collider = _collider;
        }
    }
}