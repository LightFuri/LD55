public static class MapModel
{
    public static ObjectsEnum[,] Map { get; set; }
    private static int _width { get; set; }
    private static int _height { get; set; }
    public static void Initialize()
    {
        _width = 21;
        _height = 21;
        Map = new ObjectsEnum[_width, _height];

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Map[i, j] = ObjectsEnum.Empty;
            }
        }
    }
}