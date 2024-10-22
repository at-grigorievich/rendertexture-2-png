using UnityEngine;

namespace ATG.Render2Png
{
    public class PngByTexRendererProvider
    {
        private readonly RenderTexture _textureRenderer;
        private readonly string _path;

        public PngByTexRendererProvider(RenderTexture renderTxt, string path)
        {
            _textureRenderer = renderTxt;
            _path = PngByTexRenderer.GetPngsPathRoot(path);
        }

        public void TakeScreenshot()
        {
            PngByTexRenderer.TakePng(_textureRenderer, _path);
        }

        public void OpenFolder()
        {
            PngByTexRenderer.OpenPngsFolder(_path);
        }
    }
}