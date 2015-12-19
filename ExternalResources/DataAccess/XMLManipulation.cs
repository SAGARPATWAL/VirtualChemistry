using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Media;
using ExternalResources.Apparatuses;
using LabLib.ExternalClasses.Titration_Chemicals;
using LabLib.ExternalClasses;
using LabLib.DataAccess;

namespace LabLib.DataAccess
{
    public static class XMLManipulation
    {
        public static string GetAttribute(this XElement element, string attribName)
        {
            return element.Attribute(attribName).Value.ToString();
        }
        public static List<string> GetAttributes(this XElement elem, params string[] attribs)
        {
            var attributes = elem.Attributes();
            List<string> attributeValues = new List<string>();
            foreach (var attrib in attributes)
            {
                attributeValues.Add(attrib.Value.ToString());
            }
            return attributeValues;
        }
        private const string xApparatusListPath = @"..\..\..\ExternalResources\DataAccess\Apparatus.xml";
        private const string xExperimentListPath = @"..\..\..\ExternalResources\DataAccess\Experiments.xml";
        private const string xChemicalListPath = @"..\..\..\ExternalResources\DataAccess\Chemicals.xml";

        public static List<Chemical> GetChemicals()
        {
            try
            {
                XDocument xDoc = XDocument.Load(xChemicalListPath);
                var elements = xDoc.Descendants();
                
                List<Chemical> chemicalList = new List<Chemical>();
                foreach(var elem in elements)
                {
                    if(elem.Name=="Acids")
                    {
                        var acids = elem.Descendants();
                        foreach(var acid in acids)
                        {
                            Acid experAcid = new Acid();
                            experAcid.ChemicalName = acid.GetAttribute("Name");
                            experAcid.Basisity = Double.Parse(acid.GetAttribute("Basisity"));
                            experAcid.Normality = Double.Parse(acid.GetAttribute("Normality"));
                            experAcid.Molarity = Double.Parse(acid.GetAttribute("Molarity"));

                            chemicalList.Add(experAcid);
                        }
                    }
                    else if(elem.Name=="Bases")
                    {
                        var bases = elem.Descendants();
                        foreach (var @base in bases)
                        {
                            Base experBase = new Base();
                            experBase.ChemicalName = @base.GetAttribute("Name");
                            experBase.Molarity = Double.Parse(@base.GetAttribute("Molarity"));
                            experBase.Normality = Double.Parse(@base.GetAttribute("Normality"));
                            experBase.Acidity = Double.Parse(@base.GetAttribute("Acidity"));
                            chemicalList.Add(experBase);
                        }
                    }
                    else if(elem.Name == "Indicator")
                    {
                        var indicators = elem.Descendants();
                        foreach(var indicator in indicators)
                        {
                            Indicator ind = new Indicator();
                            ind.ChemicalName = indicator.GetAttribute("Name");
                            ind.EndColor = GetColorFromString(indicator.GetAttribute("Color"));
                            chemicalList.Add(ind);
                        }
                    }
                }//foreach closed

                return chemicalList;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("System is Unable to locate file : {0}", ex.FileName);
                return null;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Cannot Access data" + ex.Message);
                return null;
            }
        }

        

        private static Color GetColorFromString(string color)
        {
            switch(color)
            {
                case "Pink": return Colors.Pink;
                case "Orange": return Colors.Orange;
                default: return Colors.Transparent;
            }
        }

        public static List<Apparatus> GetApparatuses(string experimentName = "")
        {
            try
            {
                XDocument xDoc = XDocument.Load(xApparatusListPath);
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
                                app.Experiments += exper.Attribute("name").ToString() + "1";
                            }
                            if (exper.Name == "Canvas")
                            {
                                app.CanvasProperties = new CanvasProperties();
                                app.CanvasProperties.Top = int.Parse(exper.Attribute("Top").Value);
                                app.CanvasProperties.Left = int.Parse(exper.Attribute("Left").Value);
                                app.CanvasProperties.Zindex = int.Parse(exper.Attribute("ZIndex").Value);                                
                            }
                        }
                        list.Add(app);
                    }
                }
                return list;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("System is Unable to locate file : {0}", ex.FileName);
                return null;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Cannot Access data" + ex.Message);
                return null;
            }
        }


        public static List<string> GetExperiments()
        {
            try
            {
                XDocument xDoc = XDocument.Load(xExperimentListPath);
                var elements = xDoc.Descendants();
                List<string> list = new List<string>(); 
                foreach (var elem in elements)
                {
                    if (elem.Name == "Experiment")
                    {
                        string experimentName = elem.Attribute("Name").Value.ToString();
                        list.Add(experimentName);
                    }
                }

                return list;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Couldn't find file ", ex.FileName);
                return null;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't get Experiment list");
                return null;
            }
        }
        internal static List<Apparatus> GetData()
        {
            throw new NotImplementedException();
        }
    }
}

