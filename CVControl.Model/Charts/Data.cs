using System.Collections.Generic;

namespace CVControl.Model.Charts
{
    public class Data
    {
        public List<string> labels { get; set; } = new List<string>();

        public List<DataSet> datasets { get; set; } = new List<DataSet>();
    }

    public class DataSet
        {
            public string label { get; set; }
            public double lineTension { get; set; } = 0.3;
            public string backgroundColor { get; set; } = "rgba(78, 115, 223, 0.05)";
            public string borderColor { get; set; } = "rgba(78, 115, 223, 1)";
            public double pointRadius { get; set; } = 3;
            public string pointBackgroundColor { get; set; } = "rgba(78, 115, 223, 1)";
            public string pointBorderColor { get; set; } = "rgba(78, 115, 223, 1)";
            public double pointHoverRadius { get; set; } = 3;
            public string pointHoverBackgroundColor { get; set; } = "rgba(78, 115, 223, 1)";
            public string pointHoverBorderColor { get; set; } = "rgba(78, 115, 223, 1)";
            public double pointHitRadius { get; set; } = 10;
            public double pointBorderWidth { get; set; } = 2;
            public List<int> data { get; set; } = new List<int>();
        }
    }