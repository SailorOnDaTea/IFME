﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ifme
{
	public class Global
	{
		static Random rnd = new Random();
		public static int GetRandom = rnd.Next(0, 9);

		public class App
		{
			public static string Name
			{
				get { return Application.ProductName; }
			}

			public static string NameFull
			{
				get { return $"{Name} v{VersionRelease} ({CodeName}) {(OS.Is64bit ? "64bit" : "32bit")}"; }
			}

			public static string CodeName
			{
				get { return Properties.Resources.CodeName; }
			}

			public static string Version
			{
				get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
			}

			public static string VersionRelease
			{
				get { return Application.ProductVersion; }
			}

			public static string VersionCompiled
			{
				get { return $"ifme_{Version}_{(OS.Is64bit ? "x64" : "x86")}-{(OS.IsWindows ? "windows" : "linux")}-{ReleaseType}"; }
			}

			public static string ReleaseType
			{
#if DEBUG
	#if !STEAM
				get { return "experimental"; }
	#else
				get { return "steam-experimental"; }
	#endif
#elif RELEASE
	#if !STEAM
				get { return "stable"; }
	#else
				get { return "steam-stable"; }
	#endif
#endif
			}

			public static bool NewRelease = false;
		}

		public class Sounds
		{
			public static string Finish
			{
				get { return Path.Combine(Folder.App, "sounds", "finish.wav"); }
			}
		}

		public class Folder
		{
			static string _AppPathA = Directory.GetCurrentDirectory();
			static string _AppPathB = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

			static string _DefaultSave = Path.Combine(Path.GetTempPath(), "ifme");

			public static string App
			{
				get
				{
					if (!string.IsNullOrEmpty(_AppPathA))
						return _AppPathA;
					else
						return _AppPathB;
                }
			}

			public static string Profile
			{
				get { return Path.Combine(App, "profile"); }
			}

			public static string Plugins
			{
				get { return Path.Combine(App, "plugins"); }
			}

			public static string DefaultTemp
			{
				get { if (!Directory.Exists(_DefaultSave)) { Directory.CreateDirectory(_DefaultSave); } return _DefaultSave; }
			}

			public static string DefaultSave
			{
				get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "IFME"); }
			}

			public static string Language
			{
				get { return Path.Combine(App, "lang"); }
			}

			public static string Benchmark
			{
				get { return Path.Combine(App, "benchmark"); }
			}

			public static string Extension
			{
				get { return Path.Combine(App, "extension"); }
			}
		}

		public class Files
		{
			public static string Benchmark4K
			{
				get { return Path.Combine(Folder.Benchmark, "gsmarena_v001.mp4"); }
			}
		}
	}
}
