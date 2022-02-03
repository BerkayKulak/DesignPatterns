using System.Drawing;
using System.IO;

namespace WebApp.Adapter.Services
{
    public class AdvanceImageProcessAdapter : IImageProcess
    {
        private readonly IAdvanceImageProcess _advanceImageProcess;

        public AdvanceImageProcessAdapter(IAdvanceImageProcess advanceImageProcess)
        {
            _advanceImageProcess = advanceImageProcess;
        }

        public void AddWaterMark(string text, string filename, Stream imageStream)
        {
            _advanceImageProcess.AddWatermarkImage(imageStream, text, $"wwwroot/watermarks/{filename}", Color.FromArgb(128, 255, 255, 255), Color.FromArgb(0, 255, 255, 255));
        }
    }
}
