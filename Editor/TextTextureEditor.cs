using System;
using TMPro;
using UnityEngine;

namespace Editor
{
    public class TextTextureEditor : TextMeshPro
    {
        public RenderTexture targetTexture;

#if UNITY_EDITOR

        private Transform _camObject;
        private Camera _camera;
        
        protected override void Reset()
        {
            Ensure_EditorTag();
            base.Reset();
        }

        protected override void OnEnable()
        {
            Ensure_EditorTag();
            base.OnEnable();
            
            _camObject = transform.Find("Text Camera");

            if (_camObject is null)
            {
                _camObject = new GameObject("Text Camera", typeof(Camera)).transform;
                _camObject.transform.parent = transform;
            }
            
            _camera = _camObject.GetComponent<Camera>();
            _camera.orthographic = true;
            _camera.backgroundColor = Color.clear;
            _camera.clearFlags = CameraClearFlags.Color;
        }

        protected override void OnDisable()
        {
            Ensure_EditorTag();
            base.OnDisable();
        }

        protected override void Awake()
        {
            Ensure_EditorTag();
            base.Awake();
        }

        protected void Update()
        {
            _camera.transform.localPosition = new Vector3(rectTransform.rect.center.x, rectTransform.rect.center.y, -1);
            _camera.orthographicSize = Math.Max(rectTransform.rect.width, rectTransform.rect.height) / 2 + 5;
            _camera.targetTexture = targetTexture;
            _camera.Render();
        }

        void Ensure_EditorTag()
        {
            if (!gameObject.CompareTag("EditorOnly"))
            {
                UnityEditor.EditorUtility.SetDirty(gameObject);
            }

            gameObject.tag = "EditorOnly";
        }
#endif
    }
}