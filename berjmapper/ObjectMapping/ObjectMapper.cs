using berjmapper.Messagess;
using System.Reflection;

namespace berjmapper.ObjectMapping;

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
public class ObjectMapper<TSource, TDestination>
{
    private Dictionary<string, PropertyInfo> sourcePropertyCache;
    private Dictionary<string, PropertyInfo> destinationPropertyCache;

    public ObjectMapper()
    {
        sourcePropertyCache = typeof(TSource).GetProperties().ToDictionary(p => p.Name, p => p);
        destinationPropertyCache = typeof(TDestination).GetProperties().ToDictionary(p => p.Name, p => p);
    }

    #region Methods Mapping 

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
            throw new ArgumentNullException(nameof(source), ExceptionMessage.ArgumentNullExceptionSourceMessage);
        }

        var destination = Activator.CreateInstance<TDestination>();

        foreach (var sourceProperty in sourcePropertyCache.Values)
        {
            if (destinationPropertyCache.TryGetValue(sourceProperty.Name, out var destinationProperty) &&
                destinationProperty.PropertyType == sourceProperty.PropertyType)
            {
                var sourceValue = sourceProperty.GetValue(source);
                destinationProperty.SetValue(destination, sourceValue);
            }
        }

        return destination;
    }

    public List<TDestination> Map(List<TSource> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source), ExceptionMessage.ArgumentNullExceptionnSourceListMessage);
        }

        var destinationList = new List<TDestination>();

        foreach (var sourceItem in source)
        {
            var destination = Activator.CreateInstance<TDestination>();

            foreach (var sourceProperty in sourcePropertyCache.Values)
            {
                if (destinationPropertyCache.TryGetValue(sourceProperty.Name, out var destinationProperty) &&
                    destinationProperty.PropertyType == sourceProperty.PropertyType)
                {
                    var sourceValue = sourceProperty.GetValue(sourceItem);
                    destinationProperty.SetValue(destination, sourceValue);
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
            throw new ArgumentNullException(nameof(destination), ExceptionMessage.ArgumentNullExceptionDestinationMessage);
        }

        var source = Activator.CreateInstance<TSource>();

        foreach (var destinationProperty in destinationPropertyCache.Values)
        {
            if (sourcePropertyCache.TryGetValue(destinationProperty.Name, out var sourceProperty) &&
                sourceProperty.PropertyType == destinationProperty.PropertyType)
            {
                var destinationValue = destinationProperty.GetValue(destination);
                sourceProperty.SetValue(source, destinationValue);
            }

        }

        return source;
    }

    public List<TSource> Map(List<TDestination> destinationList)
    {
        if (destinationList == null)
        {
            throw new ArgumentNullException(nameof(destinationList), ExceptionMessage.ArgumentNullExceptionDestinationListMessage);
        }

        var sourceList = new List<TSource>();

        foreach (var destinationItem in destinationList)
        {
            var source = Activator.CreateInstance<TSource>();

            foreach (var destinationProperty in destinationPropertyCache.Values)
            {
                if (sourcePropertyCache.TryGetValue(destinationProperty.Name, out var sourceProperty) &&
                    sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    var destinationValue = destinationProperty.GetValue(destinationItem);
                    sourceProperty.SetValue(source, destinationValue);
                }
            }

            sourceList.Add(source);
        }

        return sourceList;
    }
    #endregion



}
