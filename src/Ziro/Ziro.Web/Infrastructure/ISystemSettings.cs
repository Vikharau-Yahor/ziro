namespace Ziro.Web.Infrastructure
{
	public interface ISystemSettings
	{
		string ConnectionString { get; }
		bool UseCustomErrors { get; }
	}
}
