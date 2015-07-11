using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.AspectRatio {
    class AspectRatioController : BaseController {
        private AspectRatioPanel basePanel;
        public AspectRatioController(AspectRatioPanel panel) : base() {
            basePanel = panel;
        }

        public void CalcWidth(object sender, System.EventArgs e) {
            String s_height = basePanel.tb_aspectRatio_height.Text;
            try {
                String aspectRatio = basePanel.tb_aspectRatio_ratio.Text;
                int height = Convert.ToInt32(s_height);

                int[] values = GetValuesFromRatio(aspectRatio);
                int width = height / values[1] * values[0];

                basePanel.tb_aspectRatio_width.Text = width + "";
            } catch(FormatException) {
                System.Diagnostics.Debug.WriteLine("\""+s_height+"\" is not a number!");
            }
        }

        public void CalcHeight(object sender, System.EventArgs e) {
            String s_width = basePanel.tb_aspectRatio_width.Text;
            try {
                String aspectRatio = basePanel.tb_aspectRatio_ratio.Text;
                int width = Convert.ToInt32(s_width);

                int[] values = GetValuesFromRatio(aspectRatio);
                int height = width / values[0] * values[1];

                basePanel.tb_aspectRatio_height.Text = height+"";
            } catch(FormatException) {
                System.Diagnostics.Debug.WriteLine("\"" + s_width + "\" is not a number!");
            }
        }

        public void CalcRatio(object sender, System.EventArgs e) {
            String s_width = basePanel.tb_aspectRatio_width.Text;
            String s_height = basePanel.tb_aspectRatio_height.Text;
            try {
                double height = Convert.ToDouble(s_height);
                double width = Convert.ToDouble(s_width);
                double gcd = CalcGCD(width, height);
                String aspectRatio = (width / gcd) + ":" + (height / gcd);
                // (width / gcd) + ":" + (height / gcd) + " (1:" + (Math.Round((hD / wD) * 1000.00) / 1000.00) + ")";

                basePanel.tb_aspectRatio_ratio.Text = aspectRatio;
            } catch(FormatException) {
                System.Diagnostics.Debug.WriteLine("\"" + s_width + "\" or \""+s_height+"\" is not a number!");
            }

        }

        private int[] GetValuesFromRatio(String ratio) {
            int[] result = new int[2];
            try {
                String[] ratioSplit = ratio.Split(':');
                String ratio1 = ratioSplit[0].Trim();
                String ratio2 = ratioSplit[1].Trim();
                int ratio1Value = Convert.ToInt32(ratio1);
                int ratio2Value = Convert.ToInt32(ratio2);
                result[0] = ratio1Value;
                result[1] = ratio2Value;
            } catch(System.FormatException) {
                Console.WriteLine("Ratio had invalid characters. Ratio was: \"" + ratio + "\"");
                return null;
            } catch(IndexOutOfRangeException) {
                Console.WriteLine("Ratio had not \":\" to seperate ratio values! Ratio was: \"" + ratio + "\"");
                return null;
            }
            return result;
        }

        private double CalcGCD(double a, double b) {
            if(b == 0) {
                return a;
            }
            return CalcGCD(b, a % b);
        }

        public override void Close() { }
    }
}
