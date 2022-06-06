using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"./luke.jpg");

            var resultado = new PipeSerial(
                new FilterGreyscale(),
                new PipeSerial(
                    new FilterSaveToDisk("out-intermedio-1.jpg"),
                    new PipeBranch(
                        new FitlerHasFace(),
                        new PipeSerial(
                            new FilterPubToTwitter("Post de prueba"),
                            new PipeNull()
                        ),
                        new PipeSerial(
                            new FilterNegative(),
                            new PipeSerial(
                                new FilterSaveToDisk("out-intermedio-2.jpg"),
                                new PipeNull()
                            )
                        )
                    )
                )
            ).Send(picture);

            provider.SavePicture(resultado, @"out-resultado.jpg");
        }
    }
}
