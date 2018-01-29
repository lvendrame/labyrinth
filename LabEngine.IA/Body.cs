using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabEngine.IA
{
    public class BodyEventArgs : EventArgs
    {
        public Body TargetCollider { get; set; }
        public CollisionType CollisionType { get; set; }
        public int BodyIndex { get; set; }
    }

    public enum CollisionType
    {
        None = 0,
        Circle = 1,
        Square = 2,
        Both = 3
    }

    public class Body
    {
        public bool IsVisible { get; set; }

        public SquareCollider SquareCollider { get; set; }
        public CircleCollider CircleCollider { get; set; }

        public bool HasSquareCollider
        {
            get
            {
                return this.SquareCollider != null;
            }
        }
        public bool HasCircleCollider
        {
            get
            {
                return this.CircleCollider != null;
            }
        }

        public bool IsColliding(List<Body> bodies)
        {
            bool sc = this.HasSquareCollider;
            bool cc = this.HasCircleCollider;
            bool hasCollision = false;

            for (int i = 0; i < bodies.Count; i++)
            {
                Body body = bodies[i];
                
                CollisionType colType = CollisionType.None;
                if (sc && body.HasSquareCollider && this.SquareCollider.IsColliding(body.SquareCollider))
                {
                    colType = CollisionType.Square;
                }

                if (cc && body.HasCircleCollider && this.CircleCollider.IsColliding(body.CircleCollider))
                {
                    colType = colType | CollisionType.Circle;
                }

                if (colType != CollisionType.None)
                {
                    hasCollision = true;
                    this.OnCollision(body, colType, i);
                }
            }

            return hasCollision;
        }

        public virtual void OnCollision(Body target, CollisionType collisionType, int bodyIndex)
        {
            if (this.Collision != null)
            {
                BodyEventArgs ev = new BodyEventArgs();
                ev.TargetCollider = target;
                ev.CollisionType = collisionType;
                ev.BodyIndex = bodyIndex;

                this.Collision(this, ev);
            }
        }

        public event EventHandler<BodyEventArgs> Collision;

    }
}
