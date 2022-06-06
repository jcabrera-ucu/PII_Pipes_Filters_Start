namespace CompAndDel.Filters
{
    public class FilterSaveToDisk : IFilter
    {
        public string Path { get; }

        public FilterSaveToDisk(string path)
        {
            Path = path;
        }

        public IPicture Filter(IPicture image)
        {
            new PictureProvider().SavePicture(image, Path);
            return image;
        }
    }
}
