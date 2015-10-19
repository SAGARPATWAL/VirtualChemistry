using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLib.ExternalClasses
{
    public class GridProperties
    {
        public int Row;

        public int Column;

        public int ColumnSpan;

        public int RowSpan;

        public int ZIndex;
        public GridProperties(int row, int col, int rowSpan, int columnSpan,int zindex)
        {
            this.Row = row;
            this.Column = col;
            this.RowSpan = rowSpan;
            this.ColumnSpan = columnSpan;
            this.ZIndex = zindex;
        }
    }

    public class Apparatus 
    {
        private string _appratusName;
        private string _imageSource;
        private string _experiments;
        private GridProperties gridProps;

        public Apparatus()
        {
            _appratusName = "";
            _imageSource = "";
            Experiments = "";
        }
        public Apparatus(string name, string imgSource, string exp)
        {
            _appratusName = name;
            _imageSource = imgSource;
            Experiments = exp;
        }

        public GridProperties GridProperties
        {
            get { return gridProps; }
            set
            {
                gridProps = value;
            }
        }
        

        public string AppratusName
        {
            get { return _appratusName; }
            set
            {
                _appratusName = value;
            }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
            }
        }

        public string Experiments
        {
            get
            {
                return _experiments;
            }
            set
            {
                _experiments = value;
            }
        }
    }
}