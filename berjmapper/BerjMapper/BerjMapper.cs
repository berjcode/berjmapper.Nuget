using berjmapper.ObjectMapping;

namespace berjmapper.BerjMapper;

public static class BerjMapper
{
    public static TDestination Convert<TSource, TDestination>(TSource source)
    {
        var mapper = new ObjectMapper<TSource, TDestination>();
        return mapper.Map(source);
    }

    public static List<TDestination> ConvertList<TSource, TDestination>(List<TSource> source)
    {
        var mapper = new ObjectMapper<TSource, TDestination>();
        return mapper.Map(source);
    }
}
