using System;
using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.AspectRatio {
    [Serializable]
    class AspectRatioController : BaseController {
        private readonly AspectRatioPanel _basePanel;
        public AspectRatioController(AspectRatioPanel panel) {
            _basePanel = panel;
        }

        public void CalcWidth(object sender, EventArgs e) {
            String sHeight = _basePanel.TextBoxHeight.Text;
            try {
                String aspectRatio = _basePanel.TextBoxRatio.Text;
                int height = Convert.ToInt32(sHeight);

                int[] values = GetValuesFromRatio(aspectRatio);
                int width = height / values[1] * values[0];

                _basePanel.TextBoxWidth.Text = width + "";
            } catch(FormatException) {
                System.Diagnostics.Debug.WriteLine("\""+sHeight+"\" is not a number!");
            }
        }

        public void CalcHeight(object sender, EventArgs e) {
            String sWidth = _basePanel.TextBoxWidth.Text;
            try {
                String aspectRatio = _basePanel.TextBoxRatio.Text;
                int width = Convert.ToInt32(sWidth);

                int[] values = GetValuesFromRatio(aspectRatio);
                int height = width / values[0] * values[1];

                _basePanel.TextBoxHeight.Text = height+"";
            } catch(FormatException) {
                System.Diagnostics.Debug.WriteLine("\"" + sWidth + "\" is not a number!");
            }
        }

        public void CalcRatio(object sender, EventArgs e) {
            String sWidth = _basePanel.TextBoxWidth.Text;
            String sHeight = _basePanel.TextBoxHeight.Text;
            try {
                double height = Convert.ToDouble(sHeight);
                double width = Convert.ToDouble(sWidth);
                double gcd = CalcGCD(width, height);
                String aspectRatio = (width / gcd) + ":" + (height / gcd);
                // (width / gcd) + ":" + (height / gcd) + " (1:" + (Math.Round((hD / wD) * 1000.00) / 1000.00) + ")";

                _basePanel.TextBoxRatio.Text = aspectRatio;
            } catch(FormatException) {
                System.Diagnostics.Debug.WriteLine("\"" + sWidth + "\" or \""+sHeight+"\" is not a number!");
            }

        }

        private static int[] GetValuesFromRatio(String ratio) {
            int[] result = new int[2];
            try {
                String[] ratioSplit = ratio.Split(':');
                String ratio1 = ratioSplit[0].Trim();
                String ratio2 = ratioSplit[1].Trim();
                int ratio1Value = Convert.ToInt32(ratio1);
                int ratio2Value = Convert.ToInt32(ratio2);
                result[0] = ratio1Value;
                result[1] = ratio2Value;
            } catch(FormatException) {
                Console.WriteLine("Ratio had invalid characters. Ratio was: \"" + ratio + "\"");
                return null;
            } catch(IndexOutOfRangeException) {
                Console.WriteLine("Ratio had not \":\" to seperate ratio values! Ratio was: \"" + ratio + "\"");
                return null;
            }
            return result;
        }

        private static double CalcGCD(double a, double b) {
            return b == 0 ? a : CalcGCD(b, a % b);
        }

        public override void Close() { }
        public override void Serialize(FileStream fileStream) {
            throw new NotImplementedException();
        }

        public override BasePanel Deserialize() {
            throw new NotImplementedException();
        }
    }
}
