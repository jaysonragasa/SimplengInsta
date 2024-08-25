namespace SimplengInsta.Model
{
	public class PostDetailsModel : BaseModel
	{
		public UserDetailsModel UserDetails { get; set; }
		public ContentDetailsModel ContentDetails { get; set; }
	}
}
