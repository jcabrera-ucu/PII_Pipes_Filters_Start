namespace CompAndDel.Pipes
{
    public class PipeBranch : IPipe
    {
        public IConditionalFilter Filtro { get; }

        public IPipe NextPipeTrue { get; }

        public IPipe NextPipeFalse { get; }

        /// <summary>
        /// La cañería recibe una imagen, y la envia a distintas cañerias dependiendo del resultado de un
        /// filtro condicional.
        /// </summary>
        /// <param name="filtro">Filtro condicional a usar.</param>
        /// <param name="nextPipeTrue">Siguiente cañería si la condición es true</param>
        /// <param name="nextPipeFalse">Siguiente cañería si la condición es false</param>
        public PipeBranch(IConditionalFilter filtro, IPipe nextPipeTrue, IPipe nextPipeFalse)
        {
            Filtro = filtro;
            NextPipeTrue = nextPipeTrue;
            NextPipeFalse = nextPipeFalse;
        }

        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            var result = Filtro.Filter(picture);

            if (result.Condition)
            {
                return NextPipeTrue.Send(result.Picture);
            }
            else
            {
                return NextPipeFalse.Send(result.Picture);
            }
        }
    }
}
