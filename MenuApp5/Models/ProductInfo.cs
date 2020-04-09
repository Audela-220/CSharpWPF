using System;
using System.Reflection;

namespace MenuApp5.Models
{
	public static class ProductInfo
	{
		// 以下のassemblyは staticなので、初回参照時に初期化される。
		public static Assembly assembly = Assembly.GetExecutingAssembly();

		// AssemblyTitle
		private static string _title;
		public static string Title
		{
			get
			{
				// 結局、何度も書く羽目に陥ったら、やはり短い方が良いかな。
				//return _title ?? ( _title = 
				//	((AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute))).Title);

				if ( _title == null ) 
				{
					AssemblyTitleAttribute attr = Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
					if( attr != null ) 
					{
						_title = attr.Title;
					}
				}
				return _title;

			}
		}

		// AssemblyProduct
		private static string _productName;
		public static string ProductName
		{
			get
			{
				return _productName ?? (_productName = 
					((AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly,typeof(AssemblyProductAttribute))).Product);
			}
		}
		// AssemblyDescription
		private static string _description;
		public static string Description {
			get {
				return _description ?? (_description =
					((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute))).Description);
			}
		}
		// AssemblyConfiguration
		private static string _configuration;
		public static string Configuration {
			get {
				return _configuration ?? (_configuration =
					((AssemblyConfigurationAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyConfigurationAttribute))).Configuration);
			}
		}
		// AssemblyCompany
		private static string _company;
		public static string Company {
			get {
				return _company ?? (_company =
					((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute))).Company);
			}
		}
		// AssemblyCopyright
		private static string _copyright;
		public static string Copyright {
			get {
				return _copyright ?? (_copyright =
					((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute))).Copyright);
			}
		}
		// ToDo:
		//   [assembly: AssemblyTrademark("")]
		//   [assembly: AssemblyCulture("")]
		// AssemblyVersion
		private static Version _version;
		public static Version Version {
			get {
				return _version ?? (_version = assembly.GetName().Version);
			}
		}

		private static string _versionString;
		public static string VersionString
		{
			get { return _versionString ?? ( _versionString = string.Format("{0}{1}{2}{3}",
				Version.ToString(3), (IsBetaMode ? " β": ""), (Version.Revision == 0 ? "" : "rev." + Version.Revision),
				(IsDebugMode ? "Debug Mode" : "")));
			}
		}
		// AssemblyFileVersion
		private static string _fileVersion;
		public static string FileVersion {
			get {
				return _fileVersion ?? (_fileVersion =
					((AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute))).Version);
			}
		}

		public static bool IsDebugMode
		{
#if DEBUG
			get { return true; }
#else
			get { return false; }
#endif
		}

		public static bool IsBetaMode
		{
#if DEBUG
			get { return true; }
#else
			get { return false; }
#endif
		}

	}
}
