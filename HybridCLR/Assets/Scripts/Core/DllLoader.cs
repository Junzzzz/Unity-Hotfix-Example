using System.Collections.Generic;
using HybridCLR;
using UnityEngine;

namespace Core
{
    public class DllLoader : MonoBehaviour
    {
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            BetterStreamingAssets.Initialize();
            
            LoadMetadataForAOTAssemblies();

#if !UNITY_EDITOR
            System.Reflection.Assembly.Load(BetterStreamingAssets.ReadAllBytes("Assembly-CSharp.dll.bytes"));
#endif

            AssetBundle prefabAb = BetterStreamingAssets.LoadAssetBundle("prefabs");
            foreach (var o in prefabAb.LoadAllAssets())
            {
                Instantiate(o);
            }
        }

        private static List<string> AOTMetaAssemblyNames { get; } = new()
        {
            "mscorlib.dll",
            "System.dll",
            "System.Core.dll",
        };

        private static void LoadMetadataForAOTAssemblies()
        {
            // 不限补充元数据dll文件的读取方式，你可以从ab、StreamingAssets、或者裸文件下载等办法获得
            const HomologousImageMode mode = HomologousImageMode.SuperSet;
            foreach (var aotDllName in AOTMetaAssemblyNames)
            {
                // 获得某个aot dll文件所有字节
                var dllBytes = GetAssetData(aotDllName);
                // 加载assembly对应的dll，会自动为它hook。一旦aot泛型函数的native函数不存在，用解释器版本代码
                var err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
                Debug.Log($"LoadMetadataForAOTAssembly:{aotDllName}. mode:{mode} ret:{err}");
            }
        }

        private static byte[] GetAssetData(string dllName)
        {
            return BetterStreamingAssets.ReadAllBytes(dllName + ".bytes");
        }
    }
}