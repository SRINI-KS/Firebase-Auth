using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace SProvider.Models
{
	public class DateTimeModelBinder : IModelBinder
		{
			ILoggerFactory factory = new LoggerFactory();
			 private readonly IModelBinder baseBinder;
			public DateTimeModelBinder()
			{
			baseBinder = new SimpleTypeModelBinder(typeof(DateTime), factory);
			}
			public Task BindModelAsync(ModelBindingContext bindingContext)
			{
			var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			if (valueProviderResult != ValueProviderResult.None)
			{
			bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
			if (valueProviderResult.FirstValue != null && valueProviderResult.FirstValue != "")
			{
			var valueAsString = valueProviderResult.FirstValue;
			var dateTime = DateTime.ParseExact(valueAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			bindingContext.Result = ModelBindingResult.Success(dateTime);
			return Task.CompletedTask;
			}
			}
			return baseBinder.BindModelAsync(bindingContext);
			}
	}
public class DateTimeFullModelBinder : IModelBinder
		{
			ILoggerFactory factory = new LoggerFactory();
			 private readonly IModelBinder baseBinder;
			public DateTimeFullModelBinder()
			{
			baseBinder = new SimpleTypeModelBinder(typeof(DateTime), factory);
			}
			public Task BindModelAsync(ModelBindingContext bindingContext)
			{
			var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			if (valueProviderResult != ValueProviderResult.None)
			{
			bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
			if (valueProviderResult.FirstValue != null && valueProviderResult.FirstValue != "")
			{
			var valueAsString = valueProviderResult.FirstValue;
			var dateTime = DateTime.ParseExact(valueAsString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
			bindingContext.Result = ModelBindingResult.Success(dateTime);
			return Task.CompletedTask;
			}
			}
			return baseBinder.BindModelAsync(bindingContext);
			}
	}
}

