namespace CustomExtentions
{
    using System;

    public class Box
    {
        private int width = 0;
        private int height = 0;

        public Box()
        {
        }

        public Box(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
    }
}
