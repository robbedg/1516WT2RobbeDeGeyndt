﻿using Formulas;
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
        Int32 time;                        // in msec

        double theta;                      // in degrees
        double standgrav;                   // standard gravity
       
        double vcircle;                    // speed
        double acircle;                    // acceleration

        double vrectangle;
        double arectangle;

        bool started;                      // simulation running.
        bool hasCollision;                 // collision happened

        ICollision collision;

        ICircle circle;                    // circle
        IRectangle rectangle;              //Rectangle

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
            theta = (double)numericAngle.Value;
            standgrav = (double)numericStandGrav.Value;
            time = 0;

            acircle = 0;
            vcircle = 0;

            arectangle = 0;
            vrectangle = 0;

            started = false;
            hasCollision = false;

            collision = new Collision();
            circle = new Circle((double)numericCircleMass.Value, 40, 480, 0);
            rectangle = new Shapes.Rectangle((double)numericRectangleMass.Value, (double)numericStaticFriction.Value, (double)numericKineticFriction.Value, 160, 80, (480 - 120 - (int)numericDistance.Value), 0);
        }

        private void DoGame()
        {
            time += timer.Interval;

            if (hasCollision)
            {
                arectangle = collision.ResultForce(acircle, standgrav, theta, (Circle)circle, (Shapes.Rectangle)rectangle);
                
                acircle = arectangle;

                if ((arectangle <= 0)) arectangle = 0;
                vrectangle = arectangle * (time / 1000.0d);
                vcircle = vrectangle;
            }
            else
            {
                acircle = XMath.Acceleration(standgrav, theta, 0);

                if (XMath.Acceleration(standgrav, theta, rectangle.staticFriction) > 0)
                {
                    arectangle = XMath.Acceleration(standgrav, theta, rectangle.kineticFriction);
                }

                vcircle = acircle * (time / 1000.0d);
                vrectangle = arectangle * (time / 1000.0d);
            }

            textBoxCircleSpeed.Text = "" + vcircle;
            textBoxAccCircle.Text = "" + acircle;
            textBoxSpeedRect.Text = "" + vrectangle;
            textBoxRectAcc.Text = "" + arectangle;
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
            circle.X -= (int)((vcircle * 0.010) * 1000);
            rectangle.X -= (int)((vrectangle * 0.010) * 1000);

            //Check collision
            
            if (collision.CheckCollision((Circle)circle, (Shapes.Rectangle)rectangle))
            {
                //timer.Enabled = false;
                circle.X = (rectangle.X + (rectangle.width / 2)) + circle.radius;

                if (collision.ResultForce(acircle, standgrav, theta, (Circle)circle, (Shapes.Rectangle)rectangle) <= 0)
                {
                    startButton_Click(new object(), new EventArgs());
                    startButton.Enabled = false;
                    checkStopped.Checked = true;
                }
                else
                {
                    if (!hasCollision)
                    {
                        checkCollision.Checked = true;
                    }
                    hasCollision = true;
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
            if (((circle.X <= -500) || (rectangle.X <= -500)) && !checkOutframe.Checked)
            {
                startButton_Click(new object(), new EventArgs());
                startButton.Enabled = false;
                checkOutframe.Checked = true;
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
                updateButton.Enabled = true;
            }
            else
            {
                timer.Enabled = true;
                startButton.Text = "Pause";
                started = true;
                updateButton.Enabled = false;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            checkCollision.Checked = false;
            checkStopped.Checked = false;
            checkOutframe.Checked = false;
            InitTimer();
            InitGame();
            InitRenderer();
            startButton.Enabled = true;
            display.Invalidate();
        }

        private void numericDistance_ValueChanged(object sender, EventArgs e)
        {
            textBoxDistance.Text = "" + numericDistance.Value / numericPPM.Value;
        }
    }
}
