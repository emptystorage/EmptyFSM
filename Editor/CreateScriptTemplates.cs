using System.IO;
using UnityEditor;

namespace EmptyDI
{
    public static class CreateScriptTemplatesEmptyFSM
    {
        [MenuItem("Assets/Create/EmptyFSM/New State", priority = 8)]
        public static void CreateNewPresentorClass()
        {
            string path = "Assets/EmptyFSM/Editor/EmptyFSM_NewState.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "NewState.cs");
        }
    }

}
