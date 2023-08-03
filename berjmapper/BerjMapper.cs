using System.Reflection;

namespace berjmapper;

///  <summary xml:lang="tr">
/// BerjMapper, kaynak ve hedef nesnelerini birbirine dönüştürür.
/// </summary>
/// <typeparam name="TSource"></typeparam>
/// <typeparam name="TDestination"></typeparam>
/// 


/// <summary xml:lang="en">
/// BerjMapper converts source and destination objects to each other.
/// </summary>
/// <typeparam name="TSource"></typeparam>
/// <typeparam name="TDestination"></typeparam>
public class BerjMapper<TSource, TDestination>
{
    private Dictionary<string, PropertyInfo> sourcePropertyCache;
    private Dictionary<string, PropertyInfo> destinationPropertyCache;

    public BerjMapper()
    {
        sourcePropertyCache = typeof(TSource).GetProperties().ToDictionary(p => p.Name, p => p);
        destinationPropertyCache = typeof(TDestination).GetProperties().ToDictionary(p => p.Name, propa => p);


    }

    /// <summary xml:lang="en">
    /// Give the source object. Map Takes Resources.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>

    /// <summary xml:lang="tr">
    ///  Kaynak nesnesini  veriniz. Map TSource Alır.  
    ///  
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public TDestination Map(TSource source)
    {
        if (source == null)
        {
            return default(TDestination);
        }
        var destination = Activator.CreateInstance<TDestination>();
        var sourceProperties = typeof(TSource).GetProperties();
        var desinationProperties = typeof(TDestination).GetProperties();
        foreach (var sourceProperty in sourceProperties)
        {
            var desinationProperty = desinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
            if (desinationProperty != null && desinationProperty.PropertyType == sourceProperty.PropertyType)
                desinationProperty.SetValue(destination, sourceProperty.GetValue(source));

        }
        return destination;
    }

    public List<TDestination> Map(List<TSource> source)
    {
        if (source == null)
        {
            return null;
        }

        var destinationList = new List<TDestination>();

        foreach (var sourceItem in source)
        {
            var destination = Activator.CreateInstance<TDestination>();
            var sourceProperties = typeof(TSource).GetProperties();
            var desinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var desinationProperty = desinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
                if (desinationProperty != null && desinationProperty.PropertyType == sourceProperty.PropertyType)
                {
                    desinationProperty.SetValue(destination, sourceProperty.GetValue(sourceItem));
                }
            }

            destinationList.Add(destination);
        }

        return destinationList;
    }


    /// <summary xml:lang="en">
    /// It takes the target and converts it to the source. Recommended when you do two conversions at the same time.
    /// </summary>
    /// <param name="destination"></param>
    /// <returns></returns>

    /// <summary xml:lang="tr">
    ///  Hedef'i alıp kaynağa çevirir. Aynı anda iki dönüşüm yaptığınızda  Tavsiye Edilir.
    ///  
    /// </summary>
    /// <param name="destination"></param>
    /// <returns></returns>

    public TSource Map(TDestination destination)
    {
        if (destination == null)
        {
            return default(TSource);
        }

        var source = Activator.CreateInstance<TSource>();
        var sourceProperties = typeof(TSource).GetProperties();
        var destinationProperties = destination.GetType().GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = Array.Find(destinationProperties, prop => prop.Name == sourceProperty.Name);

            if (destinationProperty != null && destinationProperty.PropertyType == sourceProperty.PropertyType)
            {
                var destinationValue = destinationProperty.GetValue(destination);
                sourceProperty.SetValue(source, destinationValue);
            }
        }
        return source;
    }
}
