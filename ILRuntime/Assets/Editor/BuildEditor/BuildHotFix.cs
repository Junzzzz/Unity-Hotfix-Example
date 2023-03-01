// using System.IO;
// using UnityEditor;
// using UnityEngine;
//
// namespace Editor.BuildEditor
// {
//     [InitializeOnLoad]
//     public class BuildHotFixEditor
//     {
//         private const string ScriptAssembliesDir = "Library/ScriptAssemblies"; //加载路径
//         private const string CodeDir = "Assets/Res/Code/"; //生成的dll和pdb文件夹存放的位置
//         private const string HotfixDll = "Unity.HotFix.dll"; //加载文件夹名称
//         private const string HotfixPdb = "Unity.HotFix.pdb"; //加载文件夹名称
//
//         static BuildHotFixEditor()
//         {
//             //编译后将原有的文件覆盖掉
//             File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll),
//                 Path.Combine(CodeDir, HotfixDll + ".bytes"), true);
//
//             File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb),
//                 Path.Combine(CodeDir, HotfixPdb + ".bytes"), true);
//             Debug.Log("复制hotfix文件成功");
//         }
//     }
// }