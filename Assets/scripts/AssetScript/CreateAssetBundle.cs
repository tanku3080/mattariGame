using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

public class CreateAssetBundle
{
    static string path = "AssetBundles";
    static string veriant = "assetbundle";
    [MenuItem("_assetBundle/_build(windows64)",false)]
    static private void Build_windows64()
    {
        BuildTarget target = BuildTarget.StandaloneWindows64;

        var outPut = Path.Combine(path,target.ToString());
        if (Directory.Exists(outPut) == false)
        {
            Directory.CreateDirectory(outPut);
        }

        var buildList = new List<AssetBundleBuild>();
        foreach (string item in AssetDatabase.GetAllAssetBundleNames())
        {
            var builder = new AssetBundleBuild();
            builder.assetBundleName = item;
            builder.assetNames = AssetDatabase.GetAssetPathsFromAssetBundle(builder.assetBundleName);

            builder.assetBundleVariant = veriant + TimeZoneInfo.Utc;
            buildList.Add(builder);
        }
        if (buildList.Count > 0)
        {
            BuildPipeline.BuildAssetBundles(outPut, buildList.ToArray(), BuildAssetBundleOptions.ChunkBasedCompression,target);
        }
    }
}
