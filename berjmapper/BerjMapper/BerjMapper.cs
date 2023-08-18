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

    public static TSource ConvertReverse<TDestination, TSource>(TDestination destination)
    {
        var mapper = new ObjectMapper<TDestination, TSource>();

        return mapper.Map(destination);
    }

    public static List<TSource> ConvertListReverse<TDestination, TSource>(List<TDestination> destinationList)
    {
        var mapper = new ObjectMapper<TDestination, TSource>();

        return mapper.Map(destinationList);
    }
}
