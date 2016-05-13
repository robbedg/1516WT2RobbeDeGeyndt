using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Peek
    {
        private Coordinates _coordinates { get; set; }
        private string _name { get; set; }
        private float _height { get; set; }

        #region public getters
        public Coordinates coordinates
        {
            get { return _coordinates; }
        }
        public string name
        {
            get { return _name; }
        }
        public float height
        {
            get { return _height; }
        }
        #endregion

        public Peek()
        {
            _coordinates = new Coordinates();
        }

        public Peek(Coordinates coordinates, string name, float height)
        {
            _coordinates = coordinates;
            _name = name;
            _height = height;
        }
    }
}
