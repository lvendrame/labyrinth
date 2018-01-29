using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabEngine.IA
{
    public class CircleCollider
    {
        public CircleCollider(float x, float y, float radius)
            : this(new Point2D(x, y), radius)
        {
        }

        public CircleCollider(Point2D position, float radius)
        {
            this.Position = position;
            this.Radius = radius;
        }

        public Point2D Position { get; set; }
        public float Radius { get; set; }

        public bool IsColliding(CircleCollider collider)
        {
            float r = this.Radius + collider.Radius;
            float dx = this.Position.x - collider.Position.x;
            float dy = this.Position.y - collider.Position.y;

            return (r*r) > ((dx*dx) + (dy*dy));
        }

    }
}
