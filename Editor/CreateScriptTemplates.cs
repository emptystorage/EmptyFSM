using System.IO;
using UnityEngine;
using UnityEditor;

namespace EmptyDI
{
    public static class CreateScriptTemplatesEmptyFSM
    {
        [MenuItem("Assets/Create/EmptyFSM/New State", priority = 8)]
        public static void CreateNewPresentorClass()
        {
            string path = AssetDatabase.GetAssetPath(Resources.Load<TextAsset>("EmptyFSM_NewState.cs"));

            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("Не найден шаблон для создания cs файла для EmptyFSM State");
                return;
            }

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewState.cs");
        }
    }

}
