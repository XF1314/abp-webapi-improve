using System.Collections.Generic;

namespace Com.OPPO.Mo.Job.Hangfire
{
    /// <summary>
    /// Provides configuration for <see cref="RecurringJobInfo"/> for Hangfire.
    /// </summary>
    public interface IConfigurationProvider
	{
		/// <summary>
		/// Loads configuration values from the source represented by this <see cref="IConfigurationProvider"/>.
		/// </summary>
		/// <returns>The list of <see cref="RecurringJobInfo"/>.</returns>
		IEnumerable<RecurringJobInfo> Load();
	}
}
