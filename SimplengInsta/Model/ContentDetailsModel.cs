using SimplengInsta.Enum;

namespace SimplengInsta.Model
{
	public class ContentDetailsModel : BaseModel
	{
		public ContentTypeEnum ContentType { get; set; } = ContentTypeEnum.Picture;
		public List<string> ContentUrl { get; set; }
		public string Description { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
