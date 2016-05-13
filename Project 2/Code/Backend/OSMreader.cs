using Objects;
using OsmSharp.Osm.Xml.Streams;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class OSMreader
    {
        private FileInfo file { get; set; }
        private XmlOsmStreamSource xmlSource { get; set; }
        private List<Peek> _peeks { get; set; }

        #region public getters
        public List<Peek> peeks
        {
            get { return _peeks; }
        }
        #endregion

        public OSMreader()
        {
            _peeks = new List<Peek>();

            file = new FileInfo(@"OSMrecources\switzerland.osm");
            xmlSource = new XmlOsmStreamSource(file.OpenRead());
            xmlSource.Initialize();
            read();
        }

        private void read()
        {
            while(xmlSource.MoveNextNode())
            {
                OsmSharp.Osm.Node node = (OsmSharp.Osm.Node)xmlSource.Current();

                //Does node have a lattitude and longitude?
                if ((node != null) && (node.Latitude.HasValue) && (node.Longitude.HasValue))
                {
                    //Does the node have the correct tag?
                    string naturalValue;
                    if ((node.Tags.TryGetValue("natural", out naturalValue)) && (naturalValue.Equals("peak")))
                    {
                        Coordinates coordinates = new Coordinates((float)node.Latitude.Value, (float)node.Longitude.Value);

                        string name;
                        if (!node.Tags.TryGetValue("name", out name))
                        {
                            name = "unknown";
                        }

                        string elevation;
                        if (!node.Tags.TryGetValue("ele", out elevation))
                        {
                            elevation = "0";
                        }

                        NumberFormatInfo nfi = new NumberFormatInfo();
                        nfi.NumberDecimalSeparator = ".";

                        float floatele;
                        float.TryParse(elevation, NumberStyles.Any, nfi, out floatele);

                        _peeks.Add(new Peek(coordinates, name, floatele));
                    }
                }
            }
        }
    }
}
