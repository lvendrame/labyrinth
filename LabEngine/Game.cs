using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LabEngine.IA;
using System.Drawing;

namespace LabEngine
{
    public class Game
    {
        public PictureBox GameDraw { get; private set; }
        public bool IsRunning { get; set; }
        public Image CurrentFrame { get; set; }

        public Time Timer { get; set; }

        private WayPointMatrix Matrix;

        List<Car> lstCars = new List<Car>();

        public Game(PictureBox gameDraw)
        {
            this.GameDraw = gameDraw;
            this.IsRunning = false;
        }

        public void Start()
        {
            if (this.IsRunning)
                return;

            this.IsRunning = true;
            Thread thread = new Thread(MainLoop);
            thread.Start();
        }

        public void Stop()
        {
            lock (this)
            {
                this.IsRunning = false;
            }
        }

        public void MainLoop()
        {
            this.Initialize();
            Timer.Update();
            while (this.IsRunning)
            {
                this.Timer.Update();
                this.Update(this.Timer.ElapsedTime);
                this.Draw();
                
                GC.Collect();
                Thread.Sleep(20);
            }
        }

        private void Update(float elapsedTime)
        {
            foreach (Car car in this.lstCars)
            {
                car.Update(elapsedTime);
            }
        }

        private void Draw()
        {
            Image imgNew = new Bitmap(690, 514, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics gImg = Graphics.FromImage(imgNew))
            {
                //this.Matrix.Draw(gImg);
                foreach (Car car in this.lstCars)
                {
                    car.Draw(gImg);
                }
                gImg.Save();
            }

            lock (this)
            {
                this.CurrentFrame = imgNew;
            }
            this.GameDraw.Refresh();
        }

        public void Initialize()
        {
            this.CreateWayPoints();
            
            this.lstCars.Add(new Car(this.Matrix.FindById(34), HandRule.Left, Brushes.Cyan));
            this.lstCars.Add(new Car(this.Matrix.FindById(34), HandRule.Right, Brushes.Magenta));

            this.lstCars.Add(new Car(this.Matrix.FindById(33), HandRule.Left, Brushes.BlueViolet));
            this.lstCars.Add(new Car(this.Matrix.FindById(40), HandRule.Right, Brushes.Brown));

            this.lstCars.Add(new Car(this.Matrix.FindById(0), HandRule.Left, Brushes.Red));
            this.lstCars.Add(new Car(this.Matrix.FindById(0), HandRule.Right, Brushes.Blue));

            this.lstCars.Add(new Car(this.Matrix.FindById(62), HandRule.Left, Brushes.Black));
            this.lstCars.Add(new Car(this.Matrix.FindById(62), HandRule.Right, Brushes.Green));
            
            this.Timer = new Time();
        }

        private void CreateWayPoints()
        {
            this.Matrix = new WayPointMatrix(10, 10);

            #region Create WayPoints
            this.Matrix.Set(new WayPoint(95, 50), 0, 0);
            this.Matrix.Set(new WayPoint(204, 50), 2, 0);
            this.Matrix.Set(new WayPoint(258, 50), 3, 0);
            this.Matrix.Set(new WayPoint(313, 50), 4, 0);
            this.Matrix.Set(new WayPoint(367, 50), 5, 0);
            this.Matrix.Set(new WayPoint(476, 50), 7, 0);
            this.Matrix.Set(new WayPoint(585, 50), 9, 0);
            this.Matrix.Set(new WayPoint(95, 96), 0, 1);
            this.Matrix.Set(new WayPoint(149, 96), 1, 1);
            this.Matrix.Set(new WayPoint(204, 96), 2, 1);
            this.Matrix.Set(new WayPoint(258, 96), 3, 1);
            this.Matrix.Set(new WayPoint(367, 96), 5, 1);
            this.Matrix.Set(new WayPoint(422, 96), 6, 1);
            this.Matrix.Set(new WayPoint(476, 96), 7, 1);
            this.Matrix.Set(new WayPoint(585, 96), 9, 1);
            this.Matrix.Set(new WayPoint(95, 141), 0, 2);
            this.Matrix.Set(new WayPoint(204, 141), 2, 2);
            this.Matrix.Set(new WayPoint(258, 141), 3, 2);
            this.Matrix.Set(new WayPoint(367, 141), 5, 2);
            this.Matrix.Set(new WayPoint(476, 141), 7, 2);
            this.Matrix.Set(new WayPoint(531, 141), 8, 2);
            this.Matrix.Set(new WayPoint(204, 187), 2, 3);
            this.Matrix.Set(new WayPoint(258, 187), 3, 3);
            this.Matrix.Set(new WayPoint(367, 187), 5, 3);
            this.Matrix.Set(new WayPoint(531, 187), 8, 3);
            this.Matrix.Set(new WayPoint(95, 232), 0, 4);
            this.Matrix.Set(new WayPoint(149, 232), 1, 4);
            this.Matrix.Set(new WayPoint(204, 232), 2, 4);
            this.Matrix.Set(new WayPoint(313, 232), 4, 4);
            this.Matrix.Set(new WayPoint(367, 232), 5, 4);
            this.Matrix.Set(new WayPoint(422, 232), 6, 4);
            this.Matrix.Set(new WayPoint(476, 232), 7, 4);
            this.Matrix.Set(new WayPoint(531, 232), 8, 4);
            this.Matrix.Set(new WayPoint(585, 232), 9, 4);
            this.Matrix.Set(new WayPoint(95, 278), 0, 5);
            this.Matrix.Set(new WayPoint(149, 278), 1, 5);
            this.Matrix.Set(new WayPoint(204, 278), 2, 5);
            this.Matrix.Set(new WayPoint(258, 278), 3, 5);
            this.Matrix.Set(new WayPoint(313, 278), 4, 5);
            this.Matrix.Set(new WayPoint(422, 278), 6, 5);
            this.Matrix.Set(new WayPoint(585, 278), 9, 5);
            this.Matrix.Set(new WayPoint(204, 323), 2, 6);
            this.Matrix.Set(new WayPoint(313, 323), 4, 6);
            this.Matrix.Set(new WayPoint(367, 323), 5, 6);
            this.Matrix.Set(new WayPoint(476, 323), 7, 6);
            this.Matrix.Set(new WayPoint(531, 323), 8, 6);
            this.Matrix.Set(new WayPoint(204, 369), 2, 7);
            this.Matrix.Set(new WayPoint(367, 369), 5, 7);
            this.Matrix.Set(new WayPoint(422, 369), 6, 7);
            this.Matrix.Set(new WayPoint(476, 369), 7, 7);
            this.Matrix.Set(new WayPoint(531, 369), 8, 7);
            this.Matrix.Set(new WayPoint(149, 414), 1, 8);
            this.Matrix.Set(new WayPoint(204, 414), 2, 8);
            this.Matrix.Set(new WayPoint(258, 414), 3, 8);
            this.Matrix.Set(new WayPoint(367, 414), 5, 8);
            this.Matrix.Set(new WayPoint(422, 414), 6, 8);
            this.Matrix.Set(new WayPoint(585, 414), 9, 8);
            this.Matrix.Set(new WayPoint(95, 460), 0, 9);
            this.Matrix.Set(new WayPoint(204, 460), 2, 9);
            this.Matrix.Set(new WayPoint(313, 460), 4, 9);
            this.Matrix.Set(new WayPoint(367, 460), 5, 9);
            this.Matrix.Set(new WayPoint(531, 460), 8, 9);
            this.Matrix.Set(new WayPoint(585, 460), 9, 9); 
            #endregion

            #region Set Ways
            //linha 01
            this.Matrix.SetEast(0, 1);
            this.Matrix.SetEast(1, 2);
            this.Matrix.SetEast(2, 3);
            this.Matrix.SetEast(4, 5);
            this.Matrix.SetEast(5, 6);

            this.Matrix.SetSouth(1, 9);
            this.Matrix.SetSouth(2, 10);
            this.Matrix.SetSouth(3, 28);
            this.Matrix.SetSouth(4, 11);
            this.Matrix.SetSouth(5, 13);

            //linha 02
            this.Matrix.SetEast(7, 8);
            this.Matrix.SetEast(8, 9);
            this.Matrix.SetEast(11, 12);
            this.Matrix.SetEast(13, 14);

            this.Matrix.SetSouth(8, 26);
            this.Matrix.SetSouth(9, 16);
            this.Matrix.SetSouth(13, 19);
            this.Matrix.SetSouth(14, 33);

            //linha 03
            this.Matrix.SetEast(16, 17);
            this.Matrix.SetEast(18, 19);
            this.Matrix.SetEast(19, 20);

            this.Matrix.SetSouth(15, 25);
            this.Matrix.SetSouth(17, 22);
            this.Matrix.SetSouth(18, 23);

            //linha 04
            this.Matrix.SetEast(23, 24);

            this.Matrix.SetSouth(21, 27);
            this.Matrix.SetSouth(23, 29);

            //linha 05
            this.Matrix.SetEast(25, 26);
            this.Matrix.SetEast(27, 28);
            this.Matrix.SetEast(28, 29);
            this.Matrix.SetEast(29, 30);
            this.Matrix.SetEast(31, 32);

            this.Matrix.SetSouth(27, 36);
            this.Matrix.SetSouth(28, 38);
            this.Matrix.SetSouth(31, 44);
            this.Matrix.SetSouth(32, 45);

            //linha 06
            this.Matrix.SetEast(35, 36);
            this.Matrix.SetEast(36, 37);
            this.Matrix.SetEast(38, 39);

            this.Matrix.SetSouth(34, 57);
            this.Matrix.SetSouth(35, 51);
            this.Matrix.SetSouth(38, 42);
            this.Matrix.SetSouth(40, 56);

            //linha 07
            this.Matrix.SetEast(41, 42);
            this.Matrix.SetEast(42, 43);
            this.Matrix.SetEast(43, 44);

            this.Matrix.SetSouth(43, 47);
            this.Matrix.SetSouth(44, 49);

            //linha 08
            this.Matrix.SetEast(46, 47);
            this.Matrix.SetEast(48, 49);
            this.Matrix.SetEast(49, 50);

            this.Matrix.SetSouth(48, 55);

            //linha 09
            this.Matrix.SetEast(51, 52);
            this.Matrix.SetEast(53, 54);
            this.Matrix.SetEast(54, 55);
            this.Matrix.SetEast(55, 56);

            this.Matrix.SetSouth(52, 58);
            this.Matrix.SetSouth(54, 60);
            this.Matrix.SetSouth(56, 62);

            //linha 10
            this.Matrix.SetEast(57, 58);
            this.Matrix.SetEast(58, 59);
            this.Matrix.SetEast(60, 61);
            #endregion
            
        }
    }
}
