using System;
using System.Diagnostics;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.AspectRatio {
    class AspectRatioController : IBaseController {
        private readonly AspectRatioPanel _basePanel;
        private AspectRatioModel _model = new AspectRatioModel(); 

        public AspectRatioController(AspectRatioPanel panel) {
            _basePanel = panel;
        }

        public void DataChange(object sender, EventArgs e) {
            TextBox tb = (TextBox) sender;
            if(tb.Name == "tb_aspectRatio_height")
                _model.LastHeight = tb.Text;
            if(tb.Name == "tb_aspectRatio_ratio")
                _model.LastRatio = tb.Text;
            if(tb.Name == "tb_aspectRatio_width")
                _model.LastWidth = tb.Text;
        }

        public void CalcWidth(object sender, EventArgs e) {
            String sHeight = _model.LastHeight;
            try {
                String aspectRatio = _model.LastRatio;
                int height = Convert.ToInt32(sHeight);

                int[] values = GetValuesFromRatio(aspectRatio);
                int width = height / values[1] * values[0];

                _model.LastWidth = width+"";
                _basePanel.UpdateView();
                //_basePanel.tb_aspectRatio_width.Text = width + "";
            } catch(FormatException) {
                Debug.WriteLine("\""+sHeight+"\" is not a number!");
            }
        }

        public void CalcHeight(object sender, EventArgs e) {
            String sWidth = _model.LastWidth;
            try {
                String aspectRatio = _model.LastRatio;
                int width = Convert.ToInt32(sWidth);

                int[] values = GetValuesFromRatio(aspectRatio);
                int height = width / values[0] * values[1];

                _model.LastHeight = height + "";
                _basePanel.UpdateView();
                //_basePanel.tb_aspectRatio_height.Text = height+"";
            } catch(FormatException) {
                Debug.WriteLine("\"" + sWidth + "\" is not a number!");
            }
        }

        public void CalcRatio(object sender, EventArgs e) {
            String sWidth = _model.LastWidth;
            String sHeight = _model.LastHeight;
            try {
                double height = Convert.ToDouble(sHeight);
                double width = Convert.ToDouble(sWidth);
                double gcd = CalcGCD(width, height);
                String aspectRatio = (width / gcd) + ":" + (height / gcd);
                //String aspectRatio = (width / gcd) + ":" + (height / gcd) + " (1:" + (Math.Round((hD / wD) * 1000.00) / 1000.00) + ")";

                _model.LastRatio = aspectRatio + "";
                _basePanel.UpdateView();
                //_basePanel.tb_aspectRatio_ratio.Text = aspectRatio;
            } catch(FormatException) {
                Debug.WriteLine("\"" + sWidth + "\" or \""+sHeight+"\" is not a number!");
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

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (AspectRatioModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public virtual void Close() { }
    }
}
