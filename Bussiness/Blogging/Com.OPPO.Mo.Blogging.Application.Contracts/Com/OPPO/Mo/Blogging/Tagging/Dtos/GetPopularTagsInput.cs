namespace Com.OPPO.Mo.Blogging.Tagging.Dtos
{
    public class GetPopularTagsInput
    {
        public int ResultCount { get; set; } = 10;

        public int? MinimumPostCount { get; set; }
    }
}