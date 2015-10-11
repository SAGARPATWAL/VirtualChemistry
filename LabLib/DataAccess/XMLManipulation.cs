using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using LabLib.ViewModels;
using LabLib.ExternalClasses;
namespace LabLib.DataAccess
{
    static class XMLManipulation
    {
        private const string xPath = @"C:\Users\Manish\Documents\Visual Studio 2015\Projects\VirtualChemistry\LabLib\DataAccess\Apparatus.xml";

        

        public static List<Apparatus> GetApparatuses(string experimentName="")
        {
            try
            {
                XDocument xDoc = XDocument.Load(xPath);
                var elements = xDoc.Descendants();
                List<Apparatus> list = new List<Apparatus>();
                foreach (var elem in elements)
                {
                    if (elem.Name == "Apparatus")
                    {
                        Apparatus app = new Apparatus();
                        app.AppratusName = elem.Attribute("name").Value.ToString();
                        app.ImageSource = elem.Attribute("imageSource").Value.ToString();
                        foreach (var exper in elem.Descendants())
                        {
                            if (exper.Name == "Experiment")
                            {
                                app.Experiments +=  exper.Attribute("name").ToString() + ",";
                            }
                            if (exper.Name == "Grid")
                            {
                                int row = int.Parse(exper.Attribute("Row").Value);
                                int col = int.Parse(exper.Attribute("Column").Value);
                                int rowSpan = int.Parse(exper.Attribute("RowSpan").Value);
                                int colSpan = int.Parse(exper.Attribute("ColumnSpan").Value);
                                GridProperties gridProps = new GridProperties(row, col, rowSpan, colSpan);
                                app.GridProperties = gridProps;
                            }
                        }
                        list.Add(app);
                    }    
                }
                return list;
            }
            catch(System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("System is Unable to locate file : {0}", ex.FileName);
                return null;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("Cannot Access data" + ex.Message);
                return null;
            }
        }

        

        internal static List<Apparatus> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
