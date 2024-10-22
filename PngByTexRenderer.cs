using System.IO;
using UnityEngine;

namespace ATG.Render2Png
{
    public static class PngByTexRenderer
    {
        public static void TakePng(RenderTexture renderTexture, string rootPath)
        {
            if (renderTexture == null) return;

            RenderTexture.active = renderTexture;

            Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

            byte[] bytes = tex.EncodeToPNG();

            string pngName = $"screen_{tex.GetInstanceID()}.png";

            string path = Path.Combine(rootPath, pngName);
            System.IO.File.WriteAllBytes(path, bytes);
        }

        public static string GetPngsPathRoot(string sessionIndex)
        {
            string sessionId = $"session_{sessionIndex}";
            string pathRoot = $"{Application.persistentDataPath}/screenshots/{sessionId}";

            if (Directory.Exists(pathRoot) == false)
            {
                Directory.CreateDirectory(pathRoot);
            }

            return pathRoot;
        }

        public static void OpenPngsFolder(string path)
        {
            if (Directory.Exists(path) == false) return;

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = path,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}