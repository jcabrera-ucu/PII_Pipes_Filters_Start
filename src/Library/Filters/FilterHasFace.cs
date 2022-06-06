using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FitlerHasFace : IConditionalFilter
    {
        public string TmpPath { get; }

        public FitlerHasFace()
            : this(@"out-has-face-tmp.jpg")
        {
        }

        public FitlerHasFace(string tmpPath)
        {
            TmpPath = tmpPath;
        }

        /// Un filtro que detecta si hay una cara en la imagen.
        /// </summary>
        /// <param name="image">La imagen a en cual se va a buscar la cara.</param>
        /// <returns>La imagen recibida.</returns>
        public (IPicture, bool) Filter(IPicture image)
        {
            new PictureProvider().SavePicture(image, TmpPath);

            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(TmpPath);

            return (image, cog.FaceFound);
        }

    }
}
