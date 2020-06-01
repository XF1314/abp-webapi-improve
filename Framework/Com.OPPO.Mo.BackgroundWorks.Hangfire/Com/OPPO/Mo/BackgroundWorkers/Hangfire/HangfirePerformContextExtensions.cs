using System;
using System.Collections.Generic;
using Hangfire.Common;
using Hangfire.Server;

namespace Com.OPPO.Mo.BackgroundWorkers.Hangfire
{
    public static class HangfirePerformContextExtensions
	{
		public static object GetJobDataItemValue(this PerformContext performContext, string jobDataItemKey)
		{
			if (string.IsNullOrEmpty(jobDataItemKey)) 
				throw new ArgumentNullException(nameof(jobDataItemKey));

			var jobDataKey = $"backgroundJob-info-{performContext.BackgroundJob.Job}";
			if (!performContext.Items.ContainsKey(jobDataKey)) 
				return null;

			var jobData = performContext.Items[jobDataKey] as IDictionary<string, object>;
			if (jobData == null || jobData.Count == 0) 
				return null;

			if (!jobData.ContainsKey(jobDataItemKey)) 
				return null;

			return jobData[jobDataItemKey];
		}

		public static T GetJobDataItemValue<T>(this PerformContext performContext, string jobDataItemKey)
		{
			var jobDataItemValue = GetJobDataItemValue(performContext, jobDataItemKey);
			var jsonString = SerializationHelper.Serialize(jobDataItemValue);

			return SerializationHelper.Deserialize<T>(jsonString);
		}

		public static void SetJobDataItemValue(this PerformContext PerformContext, string jobDataItemKey, object jobDataItemValue)
		{
			if (string.IsNullOrEmpty(jobDataItemKey)) 
				throw new ArgumentNullException(nameof(jobDataItemKey));

			var jobDataKey = $"backgroundJob-info-{PerformContext.BackgroundJob.Job}";
			if (!PerformContext.Items.ContainsKey(jobDataKey))
				throw new KeyNotFoundException($"The job data key: {jobDataKey} is not found.");

			var jobData = PerformContext.Items[jobDataKey] as IDictionary<string, object>;
			jobData = jobData?? new Dictionary<string, object>();

			jobData[jobDataItemKey] = jobDataItemValue;
		}
	}
}
