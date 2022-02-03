using System.Drawing;
using System.IO;

namespace WebApp.Adapter.Services
{
    public interface IAdvanceImageProcess
    {// void AddWatermark(string text, string filename, Stream imageStream);

        void AddWatermarkImage(Stream stream, string text, string filePath, Color color, Color outlineColor);
    }
}
