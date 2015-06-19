using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.AspectRatio {
    class AspectRatio {
        public static int calcWidth(int height, String aspectRatio) {
            int[] values = getValuesFromRatio(aspectRatio);
            return height/values[1]*values[0];
        }

        public static int calcHeight(int width, String aspectRatio) {
            int[] values = getValuesFromRatio(aspectRatio);
            return width / values[0] * values[1];
        }

        public static String calcRatio(int width, int height) {
            int gcd = calcGCD(width, height);
            double hD = (double)height;
            double wD = (double)width;
            //return (width / gcd) + ":" + (height / gcd) + " (1:" + (Math.Round((hD / wD) * 1000.00) / 1000.00) + ")";
            return (width / gcd) + ":" + (height / gcd);
        }

        private static int[] getValuesFromRatio(String ratio) {
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

        private static int calcGCD(int a, int b) {
            if(b == 0) {
                return a;
            }
            return calcGCD(b, a % b);
        }
    }
}
