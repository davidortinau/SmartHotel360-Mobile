using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.MarkupExtensions
{
	[ContentProperty( "Text" )]
	public class TranslateExtension : IMarkupExtension
	{
		public string Text { get; set; }
		public string StringFormat { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			if ( Text == null )
				return null;

			var assembly = typeof( TranslateExtension ).GetTypeInfo().Assembly;
			var assemblyName = assembly.GetName();
			var resourceManager = new ResourceManager( $"{assemblyName.Name}.Resources", assembly );

			string result = resourceManager.GetString( Text, CultureInfo.CurrentCulture );
			if ( !string.IsNullOrWhiteSpace( StringFormat ) )
			{
				result = string.Format( StringFormat, result );
			}

			return result;

		}
	}
}