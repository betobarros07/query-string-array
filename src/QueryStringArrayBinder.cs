using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace O7.QueryStringArray
{
    /// <summary>
    /// QueryStringArrayBinder allow you to receive an array in your query string.
    /// </summary>
    public class QueryStringArrayBinder : IModelBinder
    {
        /// <summary>
        /// Implemented method from IModelBinder interface.
        /// </summary>
        /// <param name="bindingContext">The Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.</param>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var key = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(key);
            var type = bindingContext.ModelType.GetElementType();
            if (value != null)
            {
                var firstValue = value.FirstValue;
                if (!string.IsNullOrEmpty(firstValue))
                {
                    var stringArrayValues = firstValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (stringArrayValues.Any())
                    {
                        var arrayLength = stringArrayValues.Length;
                        var arrayValue = Array.CreateInstance(type, arrayLength);
                        var converter = TypeDescriptor.GetConverter(type);
                        arrayValue.Initialize();
                        for (int i = 0; i < arrayLength; i++)
                        {
                            var currentValue = stringArrayValues[i];
                            if (!string.IsNullOrEmpty(currentValue))
                                currentValue = currentValue.Trim();
                            var convertedValue = converter.ConvertFromString(stringArrayValues[i]);
                            arrayValue.SetValue(convertedValue, i);
                        }
                        bindingContext.Result = ModelBindingResult.Success(arrayValue);
                        return Task.CompletedTask;
                    }
                }
            }
            var baseBinder = new SimpleTypeModelBinder(type);
            return baseBinder.BindModelAsync(bindingContext);
        }
    }
}
