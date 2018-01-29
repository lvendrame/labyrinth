using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LabEngine.IA
{
    public class Car: Body
    {
        public HandRule HandRule { get; private set; }

        public WayPoint CurrentWayPoint { get; set; }

        public WayPointMatrix WayPointMatrix { get; set; }

        public Brush CarColor { get; set; }


        public Car(WayPoint initialPoint, HandRule handRule, Brush carColor)
        {

            this.HandRule = handRule;
            this.CarColor = carColor;
            this.SquareCollider = new SquareCollider(initialPoint.SquareCollider.Position, new Size2D(10, 7));
            this.Collision += new EventHandler<BodyEventArgs>(Car_Collision);
            
            this.CurrentWayPoint = null;
            this.WayPointMatrix = initialPoint.Parent;

            this.OnCollision(initialPoint, CollisionType.Square, -1);
        }

        void Car_Collision(object sender, BodyEventArgs e)
        {
            if (e.TargetCollider is WayPoint)
            {
                WayPoint wp = e.TargetCollider as WayPoint;

                if (wp != CurrentWayPoint)
                {
                    WayPoint aux = wp.GetNextWayPoint(this.CurrentWayPoint, this.HandRule);
                    this.CurrentWayPoint = wp;

                    this.Speedy = aux.SquareCollider.Position - this.SquareCollider.Position;
                    this.Speedy = this.Speedy.GetMultNormal(speedy_const);
                }
            }
        }

        public const float speedy_const = 70f;

        public Point2D Speedy { get; set; }

        public void Update(float elapsedTime)
        {


            this.SquareCollider.Position = new Point2D(
                this.SquareCollider.Position.x + (this.Speedy.x * elapsedTime),
                this.SquareCollider.Position.y + (this.Speedy.y * elapsedTime)
                );

            this.WayPointMatrix.IsColliding(this);
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(this.CarColor, new Rectangle(this.SquareCollider.Position.ToDrawPoint(), this.SquareCollider.Size.ToDrawSize()));
        }
        
    }
}
