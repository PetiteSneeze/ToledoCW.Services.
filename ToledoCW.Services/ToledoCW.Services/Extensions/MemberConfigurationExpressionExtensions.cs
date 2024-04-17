using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;

namespace ToledoCW.Services.Extensions;

public static class MemberConfigurationExpressionExtensions
{
    public static void IgnoreSourceWhenDefault<TSource, TDestination>(this IMemberConfigurationExpression<TSource, TDestination, object> opt)
    {
        var _destinationType = opt.DestinationMember.GetMemberType();
        var _defaultValue = _destinationType?.GetTypeInfo()?.IsValueType == true && _destinationType != typeof(bool)
            ? Activator.CreateInstance(_destinationType)
            : null;

        opt.Condition((_, _, srcValue, _) => !Equals(srcValue, _defaultValue));
    }
    
    public static void IgnoreSourceAndDefault<TSource, TDestination>(this IMemberConfigurationExpression<TSource, TDestination, object> opt)
    {
        var _destinationType = opt.DestinationMember.GetMemberType();
        var _defaultValue = _destinationType?.GetTypeInfo()?.IsValueType == true && _destinationType != typeof(bool)
            ? Activator.CreateInstance(_destinationType)
            : null;

        opt.Condition((_, _, srcValue, destValue) => !Equals(srcValue, _defaultValue) && !Equals(srcValue, destValue));
    }
    
    public static void SetNullFromNullableDefault(object source, object destination)
    {
        foreach (var _sourceProperty in source.GetType().GetProperties())
        {
            var _value = _sourceProperty.GetValue(source, null);

            var _underlyingType = Nullable.GetUnderlyingType(_sourceProperty.PropertyType);
            if (_underlyingType is not null)
            {
                var _defaultValue = _underlyingType.IsValueType && _underlyingType != typeof(bool)
                    ? Activator.CreateInstance(_underlyingType)
                    : null;
                if (_defaultValue == null || !_defaultValue.Equals(_value)) continue;
                var _destinationProperty = destination.GetType().GetProperty(_sourceProperty.Name);

                _destinationProperty?.SetValue(destination, null);
            }
            else if (_sourceProperty.PropertyType == typeof(string) && _value != null && string.Empty.Equals(_value))
            {
                var _destinationProperty = destination.GetType().GetProperty(_sourceProperty.Name);

                _destinationProperty?.SetValue(destination, null);
            }
        }
    }
}