using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErasmusGluten
{
    [RequireComponent(typeof(OVRGrabbable))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public partial class EdibleObjectData : ScriptableObject
    {
        [Header("Is a trigger?")]
        [SerializeField] private bool _colliderIsTrigger = false;

        public bool ColliderIsTrigger
        {
            get { return _colliderIsTrigger; }
        }

        [Header("Snap to hand?")]
        [SerializeField] private bool _isSnap = true;

        public bool IsSnap
        {
            get { return _isSnap; }
        }

        [Header("Food behaviour on collision")]
        [SerializeField] private PhysicMaterial _physicsMaterial;

        public PhysicMaterial PhysicsMaterial
        {
            get { return _physicsMaterial; }
        }

        [Header("Does object have gravity?")]
        [SerializeField] private bool _hasGravity = true;

        public bool HasGravity
        {
            get { return _hasGravity; }
        }

        [Header("Mass")]
        [SerializeField] private float _mass = .1f;

        public float Mass
        {
            get { return _mass; }
        }

        [Header("Drag")]
        [SerializeField] private float _angularDrag = .01f;

        public float AngularDrag
        {
            get { return _angularDrag; }
        }

        [Header("Scale")]
        [SerializeField] private float _scale = 2.0f;

        public float Scale
        {
            get { return _scale; }
        }
    }
}