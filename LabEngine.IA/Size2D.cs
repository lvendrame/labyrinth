using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabEngine.IA
{
    public struct Size2D
    {
        public float width, height;

        public Size2D(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public System.Drawing.Size ToDrawSize()
        {
            return new System.Drawing.Size(Convert.ToInt32(this.width), Convert.ToInt32(this.height));
        }
    }
}
