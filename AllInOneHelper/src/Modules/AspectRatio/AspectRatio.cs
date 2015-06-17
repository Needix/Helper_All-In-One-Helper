using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.AspectRatio {
    class AspectRatio : Module {
        public static void buttonEventListener(object sender, System.EventArgs e) {
            Button button = (Button)sender;
            if(button.Name == "b_aspectRatio_calcWidth")
                calcWidth();
            else if(button.Name == "b_aspectRatio_calcheight")
                calcHeight();
            else
                calcRatio();
            Console.WriteLine(sender.ToString() + " / " + e.ToString());
        }

        private static String calcWidth(int height, String aspectRatio) {

            return "";
        }

        private static String calcHeight(int width, String aspectRatio) {

            return "";
        }

        private static String calcAspectRatio(int width, int height) {
            int gcd = calcGCD(width, height);
            double hD = (double)height;
            double wD = (double)width;
            return (width / gcd) + ":" + (height / gcd) + " (1:" + (Math.Round((hD / wD) * 1000.00) / 1000.00) + ")";
        }

        private static int calcGCD(int a, int b) {
            if(b == 0) {
                return a;
            }
            return calcGCD(b, a % b);
        }
    }
}
