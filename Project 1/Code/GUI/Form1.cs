using Formulas;
using IShapes;
using Shapes;
using ILogic;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {

        // Timing

        Timer timer;

        // Globale variabelen voor GDI+
        Graphics screen;
        Bitmap backBuffer;
        float SchaalX;
        float SchaalY;

        // variabelen voor model
        Int32 time;                  // in msec

        double theta;                // in radialen;
        bool started = false;
        double vcircle;                    // speed
        double acircle;                    // acceleration

        double vrectangle;
        double arectangle;

        ICircle circle = new Circle(10, 20, 500, 0); //Circle
        IRectangle rectangle = new Shapes.Rectangle(5, 0.61, 0.47, 80, 40, -350, 0); //Rectangle

        public Form1()
        {
            InitializeComponent();
            InitGame();
            InitRenderer();
            InitTimer();
            startButton.Enabled = true;
        }

        //Timing
        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 10; // msec, f = 100 Hz;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DoGame();
            display.Invalidate(); // force redraw (& paint event);
        }

        #region game loop

        private void InitGame()
        {
            theta = 45;
            time = 0;

            acircle = 0;
            vcircle = 0;

            arectangle = 0;
            vrectangle = 0;
        }

        private void DoGame()
        {
            time += timer.Interval;

            acircle = XMath.Acceleration(9.81, theta, 0);
            vcircle = acircle * (time / 100.0d);

            double t = XMath.Acceleration(9.81, theta, rectangle.staticFriction);

            if (XMath.Acceleration(9.81, theta, rectangle.staticFriction) > 0)
            {
                arectangle = XMath.Acceleration(9.81, theta, rectangle.kineticFriction);
            }
            vrectangle = arectangle * (time / 100.0d);
        }

        #endregion game loop

        #region renderer

        private void InitRenderer()
        {
            backBuffer = new Bitmap(display.Width, display.Height);
            screen = Graphics.FromImage(backBuffer);
            // transformatie voor display met oorsprong in midden, breedte en hoogte van 1000m, rechtshandig assenstelsel
            SchaalX = display.Width / 1000.0f;
            SchaalY = display.Height / 1000.0f;
            screen.ResetTransform();
            screen.ScaleTransform(SchaalX, -SchaalY); //schaling
            screen.TranslateTransform(display.Width / (SchaalX * 2f), -display.Height / (SchaalY * 2f)); // oorsprong in centrum
            //ROTATION
            screen.RotateTransform((float)theta);
            // trigger Render voor elke refresh van display;
            display.Paint += new PaintEventHandler(PaintDisplay);
        }

        private void PaintDisplay(object sender, PaintEventArgs e)
        {
            // On_Paint event handler voor display
            Render(e.Graphics);
        }

        private void Render(Graphics output)
        {
            screen.Clear(Color.White);

            // genereer scherminhoud hier

            //assen
            screen.DrawLine(new Pen(Color.Blue), new Point(-1000, 0), new Point(1000, 0));

            // bol pad
            circle.X = (int)(500 - (vcircle * time));
            rectangle.X = (int)(-350 - (vrectangle * time));

            //Check collision
            ICollision collision = new Collision();
            if (collision.CheckCollision((Circle)circle, (Shapes.Rectangle)rectangle))
            {
                timer.Enabled = false;
                circle.X = (rectangle.X + (rectangle.width / 2)) + circle.radius;

                if (collision.ResultForce(acircle, 9.81, theta, (Circle)circle, (Shapes.Rectangle)rectangle) <= 0)
                {
                    startButton_Click(new object(), new EventArgs());
                    startButton.Enabled = false;
                }
            }

            //Draw circle
            System.Drawing.Rectangle boundingBox = new System.Drawing.Rectangle(new Point(circle.X - circle.radius, circle.Y), new Size(circle.radius * 2, circle.radius * 2));
            screen.FillEllipse(new SolidBrush(Color.Crimson), boundingBox);

            //Draw rectangle
            System.Drawing.Rectangle boundingBoxrect = new System.Drawing.Rectangle(new Point(rectangle.X - (rectangle.width / 2), rectangle.Y), new Size(rectangle.width, rectangle.height));
            screen.FillRectangle(new SolidBrush(Color.Green), boundingBoxrect);

            // toon backbuffer op display
            output.DrawImage(backBuffer, new System.Drawing.Rectangle(0, 0, display.Width, display.Height), new System.Drawing.Rectangle(0, 0, display.Width, display.Height), GraphicsUnit.Pixel);

            
            //TEMP
            if ((circle.X <= -500) || (rectangle.X <= -500))
            {
                startButton_Click(new object(), new EventArgs());
                startButton.Enabled = false;
            }
            // display textboxes
            //tijdBox.Text = String.Format("{0:F}", time / 1000.0d);
            //thetaBox.Text = String.Format("{0:F}", v);
        }

        #endregion renderer

        //interactie
        private void startButton_Click(object sender, EventArgs e)
        {
            if (started)
            {
                timer.Enabled = false;
                startButton.Text = "Start";
                started = false;
            }
            else
            {
                timer.Enabled = true;
                startButton.Text = "Pause";
                started = true;
            }
        }
    }
}
