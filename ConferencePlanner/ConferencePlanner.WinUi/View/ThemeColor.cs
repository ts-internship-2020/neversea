using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConferencePlanner.WinUi.View
{
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>() {
            "#DF51F0",
            "#BC55FA",
            "#8959E3",
            "#6255FA",
            "#516FF0"};

        /*  monochromatic
         * {
            "#240F63",
            "#8868E8",
            "#5222E3",
            "#3A2D63",
            "#401AB0"}
         * */


        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }

            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}

