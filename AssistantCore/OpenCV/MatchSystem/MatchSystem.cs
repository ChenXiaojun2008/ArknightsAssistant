using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistantCore.Debug.Log;

using OpenCvSharp;

namespace AssistantCore.OpenCV.MatchSystem
{
    public struct MatchResult
    {
        public double similarity;
        public int X;
        public int Y;
    }

    public class MatchSystem
    {
        public MatchResult matchTemplate(string srcPath, string tempPath)
        {
            LogSystem log = new LogSystem();

            try
            {
                log.writeLine($"Start Matching: srcPath {srcPath}; Template {tempPath}");

                Mat sourcePic = Cv2.ImRead(srcPath);
                Mat templatePic = Cv2.ImRead(tempPath);
                Mat matchResul = new Mat();

                float value_width = sourcePic.Width / (float)1920;
                float value_height = sourcePic.Height / (float)1080;

                Cv2.Resize(sourcePic, sourcePic, new Size(1920, 1080));

                Cv2.MatchTemplate(sourcePic, templatePic, matchResul, TemplateMatchModes.CCoeffNormed);

                Point minLoc = new Point(0, 0);
                Point maxLoc = new Point(0, 0);

                double minVal;
                double maxVal;

                Cv2.MinMaxLoc(matchResul, out minVal, out maxVal, out minLoc, out maxLoc);

                MatchResult result;
                result.similarity = Math.Round(maxVal, 4);

                float cachex = (maxLoc.X + templatePic.Cols) * value_width;
                float cachey = (maxLoc.Y + templatePic.Rows) * value_height;

                result.X = (int)cachex;
                result.Y = (int)cachey;

                log.writeLine($"Match result: Similarity {result.similarity}; X {result.X}; Y {result.Y};");

                sourcePic.Dispose();
                templatePic.Dispose();
                matchResul.Dispose();

                return result;
            }
            catch (Exception e)
            {
                if (File.Exists(srcPath))
                {
                    int index = 1;

                    log.writeLine($"Match Throw {e.Data}");
                    while (true)
                    {
                        if (File.Exists($"Debug/Images/MatchError-{index}.jpg"))
                            index++;
                        else break;
                    }
                    File.Copy(srcPath, $"Debug/Images/MatchError-{index}.jpg");
                }
                else
                {
                    log.writeLine($"Match Throw {e.Data}");
                }
                return new MatchResult();
            }
        }
        public MatchResult matchTemplateWithMask(string srcPath, string tempPath, string maskPath)
        {
            Mat sourcePic = Cv2.ImRead(srcPath);
            Mat templatePic = Cv2.ImRead(tempPath);
            Mat mask = Cv2.ImRead(maskPath, ImreadModes.Grayscale);
            Mat matchResul = new Mat();

            Cv2.MatchTemplate(sourcePic, templatePic, matchResul, TemplateMatchModes.CCoeffNormed, mask);

            Point minLoc = new Point(0, 0);
            Point maxLoc = new Point(0, 0);

            double minVal;
            double maxVal;

            Cv2.MinMaxLoc(matchResul, out minVal, out maxVal, out minLoc, out maxLoc);

            MatchResult matchResult;
            matchResult.similarity = Math.Round(maxVal, 4);

            matchResult.X = maxLoc.X + templatePic.Cols;
            matchResult.Y = maxLoc.Y + templatePic.Rows;

            sourcePic.Dispose();
            templatePic.Dispose();
            mask.Dispose();
            matchResul.Dispose();

            return matchResult;
        }

        public bool isAllBlack(string srcPath)
        {
            Mat srcImage = Cv2.ImRead(srcPath, ImreadModes.Unchanged);
            int num = 0;
            float rate;

            for (int i = 0; i < srcImage.Rows; i++)
            {
                for (int j = 0; j < srcImage.Cols; j++)
                {
                    if (srcImage.At<Vec3b>(i, j)[0] == 0 && srcImage.At<Vec3b>(i, j)[1] == 0 && srcImage.At<Vec3b>(i, j)[2] == 0)
                    {
                        num++;
                    }
                }
            }

            rate = num / (float)(srcImage.Rows * srcImage.Cols);

            if (rate > 0.20)
            {
                return true;
            }
            else return false;
        }
    }
}