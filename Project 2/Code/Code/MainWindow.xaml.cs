using HelixToolkit.Wpf;
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
using TempTester;

namespace Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MeshGeometry3D MPane(double[,] values)
        {
            MeshGeometry3D pane = new MeshGeometry3D();
            Point3DCollection corners = new Point3DCollection();

            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    corners.Add(new Point3D(i, values[i, j], j));
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

            return pane;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GeometryModel3D Pane1 = new GeometryModel3D();

            MeshGeometry3D paneMesh = MPane(Rand.GetRandoms());

            Pane1.Geometry = paneMesh;

            Pane1.Material = new DiffuseMaterial(new SolidColorBrush(Colors.LightBlue));

            DirectionalLight DirLicht1 = new DirectionalLight();
            DirLicht1.Color = Colors.White;
            DirLicht1.Direction = new Vector3D(-1, -1, -1);

            //REMOVE LATER
            AmbientLight AmbLicht1 = new AmbientLight();
            AmbLicht1.Color = Colors.Black;

            PerspectiveCamera Camera1 = new PerspectiveCamera();
            Camera1.FarPlaneDistance = 1000;
            Camera1.NearPlaneDistance = 1;
            Camera1.FieldOfView = 45;
            Camera1.Position = new Point3D(500, 500, 500);
            Camera1.LookDirection = new Vector3D(-500, -500, -500);
            Camera1.UpDirection = new Vector3D(0, 1, 0);

            Model3DGroup modelGroup = new Model3DGroup();
            modelGroup.Children.Add(Pane1);
            modelGroup.Children.Add(DirLicht1);
            //Remove LATER
            modelGroup.Children.Add(AmbLicht1);

            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            HelixViewport3D myViewport = new HelixViewport3D();
            myViewport.Camera = Camera1;
            myViewport.Children.Add(modelsVisual);
            myViewport.CameraRotationMode = CameraRotationMode.Turntable;
            myViewport.ModelUpDirection = new Vector3D(0, 1, 0);

            Canvas1.Children.Add(myViewport);

            myViewport.Height = 500;
            myViewport.Width = 500;
            Canvas.SetTop(myViewport, 0);
            Canvas.SetLeft(myViewport, 0);
            this.Width = myViewport.Width + 20;
            this.Height = myViewport.Height + 50;

            NameScope.SetNameScope(Canvas1, new NameScope());
        }
    }
}
