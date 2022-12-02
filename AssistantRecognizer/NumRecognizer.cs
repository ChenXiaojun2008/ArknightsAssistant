using OpenCvSharp;

using Sdcb;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR;
using Sdcb.PaddleOCR.Models;
using Sdcb.PaddleOCR.Models.LocalV3;

namespace AssistantRecognizer
{
    public class NumRecognizer
    {
        public string imageToString(string imagePath)
        {
            FullOcrModel model = LocalFullModels.ChineseV3;

            using (PaddleOcrAll all = new PaddleOcrAll(model)
            {
                AllowRotateDetection = true,
                Enable180Classification = true,
            })
            {
                using (Mat src = Cv2.ImRead(imagePath))
                {
                    PaddleOcrResult result = all.Run(src);
                    return result.Text;
                }
            }
        }
    }
}