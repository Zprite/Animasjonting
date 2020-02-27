using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gif
{
    class ImageCollection
    {

        public Image currentImage = null;
        private Image[] images;
        private int atFrame = -1;
        private int frameCount;
        private bool reverseMode;

        public ImageCollection(Image[] imagesIn) {
            images = imagesIn;
            frameCount = images.Length;
        }

        public ImageCollection(Image[] imagesIn, bool isReverseMode) {
            images = imagesIn;
            frameCount = imagesIn.Length;
            atFrame = frameCount;
            reverseMode = isReverseMode;
        }

        public Image GetNextImage()
        {
            if (!reverseMode)
            {
                atFrame++;
                atFrame %= frameCount;
                Console.WriteLine("atFrame: " + atFrame);
            }
            else {
                if (atFrame <= 0)
                    atFrame = frameCount - 1;
                else
                    atFrame--;
            }
            currentImage = images[atFrame];
            return currentImage;
        }
    }
}
