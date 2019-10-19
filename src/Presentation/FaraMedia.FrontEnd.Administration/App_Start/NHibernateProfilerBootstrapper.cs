using HibernatingRhinos.Profiler.Appender.NHibernate;

[assembly: WebActivator.PreApplicationStartMethod(typeof(FaraMedia.FrontEnd.Administration.App_Start.NHibernateProfilerBootstrapper), "PreStart")]
namespace FaraMedia.FrontEnd.Administration.App_Start
{
	public static class NHibernateProfilerBootstrapper
	{
		public static void PreStart()
		{
			NHibernateProfiler.Initialize();
		}
	}
}

