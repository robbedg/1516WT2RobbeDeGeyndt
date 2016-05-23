using HelixToolkit.Wpf;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Communication comm { get; set; }
        private Dictionary<Model3D, string> markers = new Dictionary<Model3D, string>();
        public MainWindow()
        {
            InitializeComponent();
            comm = new Communication();
            markers = comm.markers;
        }

        MeshGeometry3D MPane(float[,] values)
        {
            MeshGeometry3D pane = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();
            PointCollection texturepoints = new PointCollection();

            float ydistance = comm.distances[0];
            float xdistance = comm.distances[1];

            for (int y = 0; y < values.GetLength(0); y++)
            {
                for (int x = 0; x < values.GetLength(1); x++)
                {
                    corners.Add(new Point3D((y * ydistance), values[values.GetLength(0) -1 - y, x], (x * xdistance)));
                    texturepoints.Add(new Point((x * xdistance), (y * ydistance)));
                }
            }

            pane.Positions = corners;

            Int32Collection Triangles = new Int32Collection();

            for (int i = 0; i < values.Length; i++)
            {
                if (((i + 1) % values.GetLength(0)) != 0)
                {
                    Triangles.Add(i);
                    Triangles.Add(i + 1);
                    Triangles.Add(i + values.GetLength(0));

                    Triangles.Add(i + 1);
                    Triangles.Add(i + values.GetLength(0) + 1);
                    Triangles.Add(i + values.GetLength(0));
                }
            }

            pane.TriangleIndices = Triangles;

            pane.TextureCoordinates = texturepoints;

            return pane;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //GET MAP
            //Create pane
            GeometryModel3D Pane1 = new GeometryModel3D();

            //LOAD IN LOGIC
            MeshGeometry3D paneMesh = MPane(comm.heights);

            Pane1.Geometry = paneMesh;

            //paneMesh.Material
            ImageBrush imagebrush = new ImageBrush();
            imagebrush.ImageSource = new BitmapImage(new Uri("texture.bmp", UriKind.Relative));
            Pane1.Material = new DiffuseMaterial(imagebrush);
            Pane1.BackMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.LightGray));

            //GET MARKERS

            //LIGHTS

            DirectionalLight DirLicht1 = new DirectionalLight();
            DirLicht1.Color = Colors.White;
            DirLicht1.Direction = new Vector3D(-1, -1, -1);

            //REMOVE LATER
            DirectionalLight DirLicht2 = new DirectionalLight();
            DirLicht2.Color = Colors.White;
            DirLicht2.Direction = new Vector3D(1, 1, 1);

            //MAP
            Model3DGroup modelGroup = new Model3DGroup();
            modelGroup.Children.Add(Pane1);
            
            foreach (Model3D x in markers.Keys)
            {
                modelGroup.Children.Add(x);
            }

            modelGroup.Children.Add(DirLicht1);
            modelGroup.Children.Add(DirLicht2);

            //Add to visual3d
            ModelVisual3D visuals = new ModelVisual3D();
            visuals.Content = modelGroup;

            //Map
            PerspectiveCamera Camera1 = new PerspectiveCamera();
            Camera1.FarPlaneDistance = 1000000;
            Camera1.NearPlaneDistance = 1;
            Camera1.FieldOfView = 45;
            Camera1.Position = new Point3D(301, 5000, 301);
            Camera1.LookDirection = new Vector3D(301, -5000, 301);
            Camera1.LookAt(new Point3D(301, 301, 0), 0d);
            Camera1.UpDirection = new Vector3D(0, 1, 0);

            MainViewport.Camera = Camera1;
            MainViewport.Children.Add(visuals);
            MainViewport.CameraRotationMode = CameraRotationMode.Turntable;
            MainViewport.ModelUpDirection = new Vector3D(0, 1, 0);

            MainViewport.Height = 500;
            MainViewport.Width = 1000;
            Canvas.SetTop(MainViewport, 0);
            Canvas.SetLeft(MainViewport, 0);
            this.Width = MainViewport.Width;
            this.Height = MainViewport.Height + 100;

            //NameScope.SetNameScope(Canvas1, new NameScope());
        }
        //http://csharphelper.com/blog/2014/10/perform-hit-testing-in-a-3d-program-that-uses-wpf-xaml-and-c/
        private void MainViewport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the mouse's position relative to the viewport.
            Point mouse_pos = e.GetPosition(MainViewport);

            // Perform the hit test.
            HitTestResult result = VisualTreeHelper.HitTest(MainViewport, mouse_pos);

            // Display information about the hit.
            RayMeshGeometry3DHitTestResult mesh_result = result as RayMeshGeometry3DHitTestResult;

            try
            {
                // Display the name of the model.
                this.PeekName.Content = markers[mesh_result.ModelHit];

                // Display more detail about the hit.
                Console.WriteLine("Distance: " +
                    mesh_result.DistanceToRayOrigin);
                Console.WriteLine("Point hit: (" +
                    mesh_result.PointHit.ToString() + ")");

                Console.WriteLine("Triangle:");
                MeshGeometry3D mesh = mesh_result.MeshHit;
                Console.WriteLine("    (" +
                    mesh.Positions[mesh_result.VertexIndex1].ToString() + ")");
                Console.WriteLine("    (" +
                    mesh.Positions[mesh_result.VertexIndex2].ToString() + ")");
                Console.WriteLine("    (" +
                    mesh.Positions[mesh_result.VertexIndex3].ToString() + ")");
            }
            catch { }
        }
    }
}
