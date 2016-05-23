using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Logic
{
    public class CreateMarkers
    {
        private Dictionary<Model3D, string> _markers { get; set; }
        public Dictionary<Model3D, string> markers
        {
            get { return _markers; }
        }
        public CreateMarkers(float[,] heights, string[,] peeks, float[] distances)
        {
            _markers = new Dictionary<Model3D, string>();

            for (int y = 0; y < peeks.GetLength(0); y++)
            {
                for (int x = 0; x < peeks.GetLength(1); x++)
                {
                    if (peeks[y, x] != null)
                    {
                        GeometryModel3D peek = new GeometryModel3D();
                        peek.Geometry = MMarkers(x, y, heights[y, x], distances);

                        peek.Material = new DiffuseMaterial(new SolidColorBrush(Colors.DarkRed));
                        peek.BackMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.DarkRed));

                        _markers.Add(peek, peeks[y, x]);
                    }

                }
            }
        }

        MeshGeometry3D MMarkers(int x, int y, float height, float[] distances)
        {
            MeshGeometry3D pyramid = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            float cy = (y * distances[0]);
            float cx = x * distances[1];

            corners.Add(new Point3D(cy, height + 500, cx));               //0
            corners.Add(new Point3D(cy + 500, height + 1000, cx + 500));  //1
            corners.Add(new Point3D(cy - 500, height + 1000, cx + 500));  //2
            corners.Add(new Point3D(cy - 500, height + 1000, cx - 500));  //3
            corners.Add(new Point3D(cy + 500, height + 1000, cx - 500));  //4

            pyramid.Positions = corners;

            Int32Collection Triangles = new Int32Collection();

            Triangles.Add(0);
            Triangles.Add(1);
            Triangles.Add(2);

            Triangles.Add(0);
            Triangles.Add(2);
            Triangles.Add(3);

            Triangles.Add(0);
            Triangles.Add(3);
            Triangles.Add(4);

            Triangles.Add(0);
            Triangles.Add(4);
            Triangles.Add(1);

            Triangles.Add(1);
            Triangles.Add(2);
            Triangles.Add(4);

            Triangles.Add(3);
            Triangles.Add(2);
            Triangles.Add(4);

            pyramid.TriangleIndices = Triangles;

            return pyramid;
        }
    }
}
