using System;
using System.Collections.Generic;

namespace CVControl.Application.Charts
{
    public static class ChartsHelpers
    {
        private static string ToHexadecimal(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }

    public class Data
    {
        public List<string> labels { get; set; } = new List<string>();

        public List<DataSet> datasets { get; set; } = new List<DataSet>();
    }

    public class DataSet
    {
        public string label { get; set; }

        public List<int> data { get; set; } = new List<int>();
        
        public string borderColor { get; set; } = "rgba(78, 115, 223, 1)";
    }

    public class LineDataSet : DataSet
    {

        public double lineTension { get; set; } = 0.3;

        public string backgroundColor { get; set; } = "rgba(78, 115, 223, 0.05)";
        public double pointRadius { get; set; } = 3;
        public string pointBackgroundColor { get; set; } = "rgba(78, 115, 223, 1)";
        public string pointBorderColor { get; set; } = "rgba(78, 115, 223, 1)";
        public double pointHoverRadius { get; set; } = 3;
        public string pointHoverBackgroundColor { get; set; } = "rgba(78, 115, 223, 1)";
        public string pointHoverBorderColor { get; set; } = "rgba(78, 115, 223, 1)";
        public double pointHitRadius { get; set; } = 10;
        public double pointBorderWidth { get; set; } = 2;

    }

    public class DonutDataSet : DataSet
    {
        public List<string> backgroundColor { get; set; } = new List<string>();
        public List<string> hoverBackgroundColor { get; set; } = new List<string>();
        public string borderAlign { get; set; } = "center";
        public double borderWidth { get; set; } = 2;
        public string hoverBorderColor { get; set; } = "rgba(78, 115, 223, 1)";
        public double hoverBorderWidth { get; set; } = 2;
        public double weight { get; set; } = 2;
    }

    public class BarDataSet : DataSet
    {
        public string backgroundColor { get; set; } = "rgba(78, 115, 223, 0.05)";
        public string hoverBackgroundColor { get; set; } = "rgba(78, 115, 223, 0.05)";
        public double borderWidth { get; set; } = 2;



    }
}