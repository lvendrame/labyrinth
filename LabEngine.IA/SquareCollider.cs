using System;
using System.Collections.Generic;
using System.Text;

namespace LabEngine.IA
{
    public class SquareCollider
    {
        public SquareCollider(float x, float y, float width, float height)
            :this(new Point2D(x,y), new Size2D(width, height))
        {
        }

        public SquareCollider(Point2D position, Size2D size)
        {
            this.Position = position;
            this.Size = size;
        }

        public Point2D Position { get; set; }
        public Size2D Size { get; set; }

        public bool IsColliding(SquareCollider collider)
        {
            Point2D meLimits = this.GetLimits();
            if (collider.Position.x > meLimits.x)
                return false;

            if (collider.Position.y > meLimits.y)
                return false;

            Point2D coliderLimits = collider.GetLimits();

            if (coliderLimits.x < this.Position.x)
                return false;

            if (coliderLimits.y < this.Position.y)
                return false;

            return true;
        }

        public Point2D GetLimits()
        {
            return this.Position.GetLimits(this.Size);
        }

    }
}
