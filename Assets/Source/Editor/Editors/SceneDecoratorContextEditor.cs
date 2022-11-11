#if !ODIN_INSPECTOR

using System.Linq;
using UnityEditor;

namespace Zenject
{
    [CustomEditor(typeof(SceneDecoratorContext))]
    [NoReflectionBaking]
    public class SceneDecoratorContextEditor : ContextEditor
    {
        private SerializedProperty _decoratedContractNameProperty;

        protected override string[] PropertyNames
        {
            get
            {
                return base.PropertyNames.Concat(new[]
                    {
                        "_lateInstallers",
                        "_lateInstallerPrefabs",
                        "_lateScriptableObjectInstallers"
                    })
                    .ToArray();
            }
        }

        protected override string[] PropertyDisplayNames
        {
            get
            {
                return base.PropertyDisplayNames.Concat(new[]
                    {
                        "Late Installers",
                        "Late Prefab Installers",
                        "Late Scriptable Object Installers"
                    })
                    .ToArray();
            }
        }

        protected override string[] PropertyDescriptions
        {
            get
            {
                return base.PropertyDescriptions.Concat(new[]
                    {
                        "Drag any MonoInstallers that you have added to your Scene Hierarchy here. They'll be installed after the target installs its bindings",
                        "Drag any prefabs that contain a MonoInstaller on them here. They'll be installed after the target installs its bindings",
                        "Drag any assets in your Project that implement ScriptableObjectInstaller here. They'll be installed after the target installs its bindings"
                    })
                    .ToArray();
            }
        }

        public override void OnEnable()
        {
            base.OnEnable();

            _decoratedContractNameProperty = serializedObject.FindProperty("_decoratedContractName");
        }

        protected override void OnGui()
        {
            base.OnGui();

            EditorGUILayout.PropertyField(_decoratedContractNameProperty);
        }
    }
}

#endif