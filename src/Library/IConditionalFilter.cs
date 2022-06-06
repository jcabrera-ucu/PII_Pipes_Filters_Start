namespace CompAndDel
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él. Al mismo tiempo retorna un booleano que puede ser usado un un pipe condicional.
    /// </remarks>
    public interface IConditionalFilter
    {
        /// <summary>
        /// Procesa la imagen pasada por parametro y retorna la misma imagen o una nueva.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La misma imagen o una nueva imagen creada por el filtro y un booleano</returns>
        (IPicture Picture, bool Condition) Filter(IPicture image);
    }
}
