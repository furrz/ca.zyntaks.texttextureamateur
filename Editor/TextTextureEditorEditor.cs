#if UNITY_EDITOR
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    [CustomEditor(typeof(TextTextureEditor), true)]
    public class TextTextureEditorEditor : TMP_EditorPanel
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            var headerBox = new Box
            {
                style =
                {
                    paddingBottom = 10,
                    paddingLeft = 10,
                    paddingRight = 10,
                    paddingTop = 10,
                    flexDirection = FlexDirection.Column
                }
            };
            headerBox.Add(new Label("Text Texture Editor")
            {
                style =
                {
                    fontSize = 24,
                    unityTextAlign = TextAnchor.MiddleCenter,
                    width = Length.Percent(100)
                }
            });
            
            headerBox.Add(new Label("by @PrinceZyntaks")
            {
                style =
                {
                    fontSize = 10,
                    opacity = 0.7f,
                    marginBottom = 10
                }
            });
            
            headerBox.Add(new Label("This component will render text to the selected <b>RenderTexture</b>. This component and the gameObject it is on will be excluded entirely from the actual game build.")
            {
                style =
                {
                    whiteSpace = WhiteSpace.Normal,
                    marginBottom = 5
                }
            });
            
            
            headerBox.Add(new Label("This component will try to fit your text's bounding rectangle into the render texture's area.")
            {
                style =
                {
                    whiteSpace = WhiteSpace.Normal,
                    marginBottom = 5
                }
            });
            
            
            headerBox.Add(new Label("To set up custom fonts, adjust the TextMeshPro properties below as you usually would.")
            {
                style =
                {
                    whiteSpace = WhiteSpace.Normal,
                    marginBottom = 10
                }
            });
            
            headerBox.Add(new PropertyField(serializedObject.FindProperty("targetTexture"))
            {
                style =
                {
                    width = Length.Percent(100)
                }
            });

            root.Add(headerBox);

            root.Add(new IMGUIContainer(base.OnInspectorGUI));

            return root;
        }
    }
}
#endif
